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
            return View();
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
