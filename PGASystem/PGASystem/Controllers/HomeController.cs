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
    public class HomeController : Controller
    {
        private readonly IApplication _application;
        private readonly IApplicationFiles _applicationFiles;
        private IConfiguration _config;

        /* Dependency injection, decoupled from database */
        public HomeController(IApplication application, IConfiguration configuration, IApplicationFiles applicationFiles)
        {   
            _config = configuration;
            _application = application;
            _applicationFiles = applicationFiles;
        }

        public IActionResult Index()
        {
            /*var fileList = _application.GetAllFiles(8);

            var application = new ApplicationViewModel 
            {   
                Files  = fileList
            };
            return View(application);*/
            var model = new UploadFileModel();

            return View(model);

        }


     /*   public IActionResult Upload()
        {

        }*/


        [HttpPost]
        public async Task<IActionResult> UploadNewFile(IFormFile file, string title)
        {
            /* Send the connection string and the name of the container on Azure Blob Storage */
            string azureConnection = _config.GetConnectionString("AzureStorageConnectionString");
            var container = _applicationFiles.GetBlobContainer(azureConnection, "applicationfiles");
            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            /* Returns name with quotes */ 
            var fileName = content.FileName.Trim('"');

            /* Get a reference to a block blob */
            var blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            await _applicationFiles.SetFile(title, blockBlob.Uri);



            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/Register
  /*      [HttpPost]

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
                // additional logic omitted
                _context.Applications.Add(user);
                _context.SaveChanges();

              
               
                //System.IO.File.WriteAllBytes("myfile.pdf", returnImage);
                // Don't rely on or trust the model.AvatarImage.FileName property 
                // without validation.
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
        }*/
    }
}
