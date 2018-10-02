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

       
        public int GetLastApplicationId()
        {
            return _ctx.Applications
                       .Include(a => a.ApplicationFiles)
                       .Include(a => a.Supervisor)
                       .Include(a => a.Programme)
                       .Last().Id;
        }



        public void  Add(Application application)
        {
            _ctx.Add(application);
             _ctx.SaveChanges();


        }


       

        public void  SetApplicationStatus(int applicationId, string status)
        {
            Application app = _ctx.Applications.FirstOrDefault(a => a.Id == applicationId);
            app.ApplicationStatus = status;
             _ctx.SaveChanges();
        }



        /* Set Decision taken and Reject reason in DB*/ 
        public void SetSupervisorApproval(int applicationId, string supervisorApproval)
        {
            var application = _ctx.Applications
                        .FirstOrDefault(a => a.Id == applicationId);

            application.SupervisorApproval = supervisorApproval;

             _ctx.SaveChanges();
        }


        public void SetSupervisorRejectionReason(int applicationId, string rejectReason)
        {
            Application app = _ctx.Applications.FirstOrDefault(a => a.Id == applicationId);
            app.SupervisorRejectReason = rejectReason;
             _ctx.SaveChanges();
        }

        public void SetPGCApproval(int applicationId, string pgcApproval)
        {
            var application = _ctx.Applications
                        .FirstOrDefault(a => a.Id == applicationId);

            application.PGCApproval = pgcApproval;

             _ctx.SaveChanges();
        }

        public void SetPGCRejectionReason(int applicationId, string rejectReason)
        {
            Application app = _ctx.Applications.FirstOrDefault(a => a.Id == applicationId);
            app.PGCRejectReason = rejectReason;
            _ctx.SaveChanges();
        }


        public IEnumerable<Application> GetPGCReviewApplications()
        {
            return _ctx.Applications
                       .Include(a=> a.Programme)
                       .Include(a=>a.Supervisor)
                       .Where(a => a.ApplicationStatus == "Pending_PGC_Approval");
        }

        public IEnumerable<Application> GetReviewedApplications()
        {
            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Include(a => a.Supervisor)
                       .Where(a => a.ApplicationStatus == "Pending_PGO_Review");

        }


        public IEnumerable<Application> GetApplicationsForSupervisor(int supervisorId)
        {

            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Include(a => a.Supervisor)
                       .Where(a => a.Supervisor.Id == supervisorId && a.ApplicationStatus == "Pending_Supervisor_Approval");
        }

        public IEnumerable<Application> GetPendingApplications() 
        {
            /* This method returns all applications that are still in the application process from the db */
            var pending_status = new List<string> { "Pending_Supervisor_Approval", "Pending_PGC_Approval"};
            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Include(a => a.Supervisor)
                       .Where(a => pending_status.Contains(a.ApplicationStatus))
                       .OrderByDescending(a=> a.ApplicationStatus);
        }
    }
}
