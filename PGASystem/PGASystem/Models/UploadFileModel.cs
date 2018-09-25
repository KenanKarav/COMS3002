using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace PGASystem.Models
{
    public class UploadFileModel
    {
        public List<string> Title { get; set; }
        public IEnumerable<IFormFile> FileUpload { get; set; }
    }
}
