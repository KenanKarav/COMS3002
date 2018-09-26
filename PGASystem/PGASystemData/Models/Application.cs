using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGASystemData.Models
{
    public class Application
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Programme Programme { get; set; }
        public Users Supervisor { get; set; }
        public IEnumerable<ApplicationFiles> ApplicationFiles {get; set;}

        /* Attributes for PGC, Supervisor approval */

    }
}
