using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGASystemData.Models;

namespace PGASystem.Models
{
    public class UploadApplicationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SupervisorId { get; set; }
        public int ProgrammeId { get; set; }
       
        public List<string> Title { get; set; }
        public IEnumerable<IFormFile> FileUpload { get; set; }


        public List<SelectListItem> Programmes { get; set; }
        public List<SelectListItem> Supervisors{ get; set; }

       
    }
}
