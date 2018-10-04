using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PGASystem.Models;
using PGASystemData;
using PGASystemData.Models;

namespace PGASystem.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplication _application;
        private readonly IApplicationFiles _applicationFiles;
        private readonly IProgramme _programme;
        private readonly IUser _user; 
        private IConfiguration _config;
        private IEmail _email;
        

        /* Dependency injection, decoupled from database */
        public ApplicationController(IApplication application, 
                                     IConfiguration configuration, 
                                     IApplicationFiles applicationFiles, 
                                     IProgramme programme,
                                     IUser user, IEmail email)
        {
            _config = configuration;
            _application = application;
            _applicationFiles = applicationFiles;
            _user = user;
            _programme = programme;
            _email = email;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            /* Create an empty ViewModel */
            var model = new UploadApplicationModel()
            {
                /* Send a SelectListItem type to the view */
                Programmes = _programme.GetAllProgrammes(),
                Supervisors = _user.GetSupervisors()
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadNewFile(
            [Bind("FirstName", "LastName", "SupervisorId", "ProgrammeId" )] UploadApplicationModel uploadApplication,
            IEnumerable<IFormFile> file, 
            List<string> title)
        {

            /* Create a new object application with attributes from the HttpPost to add to the database */
            var application = new Application
            {
                FirstName = uploadApplication.FirstName,
                LastName = uploadApplication.LastName,
                Programme = _programme.GetProgrammeById(uploadApplication.ProgrammeId),
                Supervisor = _user.GetSupervisorById(uploadApplication.SupervisorId),
                ApplicationStatus = "Pending_Supervisor_Approval"
            };



              _application.Add(application);


            int i = 0; 
            foreach (var f in file)
            {

                /* Get all titles from frontend */ 
                string fileTitle = title.ElementAt(i);
                i = i + 1;

                /* Send the connection string and the name of the container on Azure Blob Storage */
                string azureConnection = _config.GetConnectionString("AzureStorageConnectionString");
                var container = _applicationFiles.GetBlobContainer(azureConnection, "applicationfiles");
                var content = ContentDispositionHeaderValue.Parse(f.ContentDisposition);

                /* Returns name without quotes */
                var fileName = content.FileName.Trim('"');

                /* Get a reference to a block blob */
                var blockBlob = container.GetBlockBlobReference(fileName);
                await blockBlob.UploadFromStreamAsync(f.OpenReadStream());
                await _applicationFiles.SetFile(fileTitle, blockBlob.Uri);
            }


            /* Use service to send email to supervisor */ 
            _email.sendEmail(application.Supervisor.Email, application.Supervisor.FirstName, "Pending Supervisor approval", "Please view https://pgasystem.azurewebsites.net/ViewFiles/?applicationId=" + _application.GetLastApplicationId());
            return RedirectToAction("Create");
        }



        [Authorize]
        public IActionResult ViewFiles(int applicationId)
        {
            /* Create an empty ViewModel */
            var model = new ApplicationViewModel()
            {
                application = _application.GetApplication(applicationId),
                Files= _applicationFiles.GetFilesForApplication(applicationId)
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult SupervisorApproval(ApplicationViewModel avm)
        {

            /* Set supervisor approval to values retrived from HttpPost */ 
            _application.SetSupervisorApproval(avm.application.Id, avm.application.SupervisorApproval);
            if(avm.application.SupervisorApproval == "Reject")
            {
                _application.SetSupervisorRejectionReason(avm.application.Id, avm.application.SupervisorRejectReason);
            }
            _application.SetApplicationStatus(avm.application.Id, "Pending_PGC_Approval");


         
      

            return RedirectToAction("SupervisorViewApplications");
        }

        [Authorize]
        [HttpPost]
        public  IActionResult PGCApproval(ApplicationViewModel avm)
        {

            /* Set PGC approval to values retrived from HttpPost */
            _application.SetPGCApproval(avm.application.Id, avm.application.PGCApproval);
            if (avm.application.PGCApproval == "Reject")
            {
                _application.SetPGCRejectionReason(avm.application.Id, avm.application.PGCRejectReason);
            }

            _application.SetApplicationStatus(avm.application.Id, "Pending_PGO_Review");


            return RedirectToAction("PGCViewApplications");
        }

        [Authorize]
        public IActionResult SupervisorViewApplications()
        {

            var model = new ApplicationsViewModel()
            {
                Applications = _application.GetApplicationsForSupervisor(Convert.ToInt16(User.Claims.ElementAt(0).Value))
               /* Use user claim defined in startup and login, which has the user id to get all applications */ 
            };
          
            return View("AssignedApplications",model);
            
        }

        [Authorize]
        public IActionResult ReviewedApplications()
        {
            var model = new ApplicationsViewModel()
            {
                Applications = _application.GetReviewedApplications()
                /* Get all applications that have been reviewed by the supervisor and PGC */ 

            };

            return View(model);
        }

        [Authorize]
        public IActionResult PGCViewApplications()
        {
            var model = new ApplicationsViewModel()
            {
                Applications = _application.GetPGCReviewApplications()
                /* Get all applications that have been reviewed by the supervisor and PGC */

            };

            return View("AssignedApplications", model);
        }


        [Authorize]
        public IActionResult PendingApplications()
        {

            var model = new ApplicationsViewModel()
            {
                Applications = _application.GetPendingApplications()
                /* Get all applications that are still in the application approval process*/

            };

            return View(model);
        }
    }
}
