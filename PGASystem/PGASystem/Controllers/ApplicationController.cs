using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        

        /* Dependency injection, decoupled from database */
        public ApplicationController(IApplication application, 
                                     IConfiguration configuration, 
                                     IApplicationFiles applicationFiles, 
                                     IProgramme programme,
                                     IUser user)
        {
            _config = configuration;
            _application = application;
            _applicationFiles = applicationFiles;
            _user = user;
            _programme = programme;
        }

        public IActionResult Index()
        {

            return View();
        }

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
                Supervisor = _user.GetSupervisorById(uploadApplication.SupervisorId)
            };



             await _application.Add(application);


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


            return RedirectToAction("Create");
        }




        /* CODE FOR STORING FILE IN SQL DATABASE 

                // POST: /Account/Register
                [HttpPost]

                public async Task<IActionResult> UploadFiles(ApplicationViewModel model)
                {

                    if (ModelState.IsValid)
                    {
                        var user = new Application
                        {
                            Id = model.Id,


                        };
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.AvatarImage.CopyToAsync(memoryStream);
                            user.image = memoryStream.ToArray();
                        }

                        _context.Applications.Add(user);
                        _context.SaveChanges();



                    }

                    return View("Index");

                }



                [HttpGet]
                public IActionResult ViewFile()
                {
                    var user =  _context.Applications.FirstOrDefault(applicant => applicant.Id == 9);

                    var returnModel = new ApplicationViewModel {
                        Id = user.Id,

                    };

                    returnModel.ReturnImage = System.Convert.ToBase64String(user.image);
                    return View(returnModel);
                }
*/
  

        public IActionResult ViewFiles(int Id)
        {
            /* Create an empty ViewModel */
            var model = new ApplicationViewModel()
            {
                application = _application.GetApplication(Id),
                Files= _applicationFiles.GetFilesForApplication(Id)
            };
            return View(model);
        }
    }
}
