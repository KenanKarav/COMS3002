using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGASystemData.Models;

namespace PGASystemData
{
    public interface IProgramme
    {
        List<SelectListItem> GetAllProgrammes();
    }
}
