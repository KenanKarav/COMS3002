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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
