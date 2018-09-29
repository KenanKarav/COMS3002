
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;
using PGASystemData.Models;

namespace PGASystem.Models
{
    public class ApplicationsSupervisor
    {
        public IEnumerable<Application> ApplicationsAssigned { get; set; }
    }
}
