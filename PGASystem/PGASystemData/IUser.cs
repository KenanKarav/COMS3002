using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PGASystemData.Models;

namespace PGASystemData
{
    public interface IUser
    {
        List<SelectListItem> GetSupervisors();
    }
}
