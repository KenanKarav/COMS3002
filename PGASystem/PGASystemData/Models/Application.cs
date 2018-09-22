using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGASystemData.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int studentNumber { get; set; }
        public IEnumerable<ApplicationFiles> ApplicationFiles {get; set;}

    }
}
