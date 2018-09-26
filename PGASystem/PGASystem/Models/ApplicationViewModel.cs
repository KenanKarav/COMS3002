using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGASystemData.Models;

namespace PGASystem.Models
{
    public class ApplicationViewModel
    {
        public Application application { get; set; }
        public List<SelectListItem> Files { get; set; } 
    }
}
