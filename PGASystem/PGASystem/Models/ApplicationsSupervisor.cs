
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;
using PGASystemData.Models;

namespace PGASystem.Models
{
    public class Applications
    {
        public IEnumerable<Application> ApplicationsAssigned { get; set; }
    }
}
