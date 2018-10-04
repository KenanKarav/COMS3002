using System;
using System.Collections.Generic;
using PGASystemData;
using PGASystemData.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PGASystemServices
{
    public class ProgrammeService : IProgramme
    {
        private readonly PGAContext _ctx;
        public ProgrammeService(PGAContext ctx)
        {
            _ctx = ctx;
        }


        /* This method retrieves all the programmes in the context */
        public List<SelectListItem> GetAllProgrammes()
        {
            return _ctx.Programme.AsNoTracking().Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.ProgrammeName
            }).ToList();
            /* Any entities that your query returns are automatically tracked by the context. 
             * In cases where the data is read-only i.e. it is being used for display purposes on a 
             * web page and will not be modified during the current request, 
             * it is not necessary to have the context 
             * perform the extra work required to set up tracking. */
        }

        public Programme GetProgrammeById(int programmeId)
        {
            return _ctx.Programme

                       .FirstOrDefault(u => u.Id == programmeId);
        }
    }
}
