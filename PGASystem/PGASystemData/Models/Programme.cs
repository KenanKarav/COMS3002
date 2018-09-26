using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PGASystemData.Models
{
    public class Programme
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProgrammeName { get; set; }
        public string Description { get; set; }
    }
}
