using System;
namespace PGASystemData.Models
{
    public class ApplicationFiles
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Created { get; set; }
            public string Url { get; set; }
            public Application Application { get; set; }
    }
}
