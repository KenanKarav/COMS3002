using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using PGASystemData.Models;

namespace PGASystem.Models
{
    public class ApplicationViewModel
    {
         public IEnumerable<ApplicationFiles> Files;
    }
}
