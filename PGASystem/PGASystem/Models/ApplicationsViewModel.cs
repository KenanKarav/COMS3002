
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;
using PGASystemData.Models;

namespace PGASystem.Models
{
    public class ApplicationsViewModel
    {
        public IEnumerable<Application> Applications { get; set; }
    }
}
