using System;
using System.ComponentModel.DataAnnotations;

namespace PGASystemData.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string name;
        public byte[] Image { get; set; }

    }
}
