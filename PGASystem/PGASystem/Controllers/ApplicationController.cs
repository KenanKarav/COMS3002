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
        private IConfiguration _config;

        /* Dependency injection, decoupled from database */
        public ApplicationController(IApplication application, IConfiguration configuration, IApplicationFiles applicationFiles)
        {
            _config = configuration;
            _application = application;
            _applicationFiles = applicationFiles;
        }

        public IActionResult Index()
        {
            /* Create an empty ViewModel */
            var model = new UploadFileModel();
            return View(model);
        }

        public IActionResult Create()
        {
            /* Create an empty ViewModel */
            var model = new UploadFileModel();
            return View(model);
        }





        [HttpPost]
        public async Task<IActionResult> UploadNewFile(IEnumerable<IFormFile> file, List<string> title)
        {
            /* Send the connection string and the name of the container on Azure Blob Storage */
            int i = 0; 
            foreach (var f in file)
            {

                /* Get all titles from frontend */ 
                string fileTitle = title.ElementAt(i);
                i = i + 1;

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


    }
}
