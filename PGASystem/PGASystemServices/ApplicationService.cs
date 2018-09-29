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
                       .Include(a => a.ApplicationFiles)
                       .FirstOrDefault(a => a.Id == applicationId).ApplicationFiles;
        }

        public Application GetApplication(int applicationId)
        {
            return _ctx.Applications
                       .Include(a => a.ApplicationFiles)
                       .Include(a => a.Supervisor)
                       .Include(a => a.Programme)
                       .FirstOrDefault(a => a.Id == applicationId);
        }

        public IEnumerable<Application> GetApplicationsForSupervisor(int supervisorId)
        {

            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Where(a => a.Supervisor.Id == supervisorId);
        }
        public int GetLastApplicationId()
        {
            return _ctx.Applications
                       .Include(a => a.ApplicationFiles)
                       .Include(a => a.Supervisor)
                       .Include(a => a.Programme)
                       .Last().Id;
        }

        public async Task ApplicationSupervisorApproval(int applicationId, string supervisorApproval)
        {
           var application =  _ctx.Applications
                       .FirstOrDefault(a => a.Id == applicationId);

            application.SupervisorApproval = supervisorApproval;

            await _ctx.SaveChangesAsync();
        }

        public async Task Add(Application application)
        {
            _ctx.Add(application);
            await _ctx.SaveChangesAsync();

            /* return the ID of the most recently added application */ 

        }


       

       
    }
}
