using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PGASystemData;
using PGASystemData.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace PGASystemServices
{
    public class ApplicationService : IApplication
    {
        private readonly PGAContext _ctx;

        public ApplicationService(PGAContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ApplicationFiles> GetAllFiles(int applicationId)
        {
            return _ctx.Applications
                       .Include( a => a.ApplicationFiles)
                       .FirstOrDefault(a => a.Id == applicationId).ApplicationFiles;
        }

        public async Task Add(Application application)
        {
            _ctx.Add(application);
            await _ctx.SaveChangesAsync();

            /* return the ID of the most recently added application */ 

        }


       

       
    }
}
