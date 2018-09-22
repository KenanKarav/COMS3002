using System;
using Microsoft.AspNetCore.Http;

namespace PGASystem.Models
{
    public class UploadFileModel
    {
        public string Title { get; set; }
        public IFormFile FileUpload { get; set; }
    }
}
