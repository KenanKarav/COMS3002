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
        /* Method gets all files pertaining to a specific application */
        public IEnumerable<ApplicationFiles> GetAllFiles(int applicationId)
        {


            Application application = _ctx.Applications
                       .Include(a => a.ApplicationFiles)
                       .FirstOrDefault(a => a.Id == applicationId);
            /* If no such applicationId exits throw an exception */
            if (application is null)
            {
                throw new Exception("Application does not exist");
            }

            return application.ApplicationFiles;
        }
        /* Method gets Application object from applicationId */
        public Application GetApplication(int applicationId)
        {
            Application application = _ctx.Applications
                       .Include(a => a.ApplicationFiles)
                       .Include(a => a.Supervisor)
                       .Include(a => a.Programme)
                       .FirstOrDefault(a => a.Id == applicationId);
            /* If applicationId is invalid then an exception is thrown */
            if (application is null)
            {
                throw new Exception("Application does not exist");
            }

            return application;
        }

        /* Method gets last application in the context */
        public int GetLastApplicationId()
        {
            return _ctx.Applications
                       .Include(a => a.ApplicationFiles)
                       .Include(a => a.Supervisor)
                       .Include(a => a.Programme)
                       .Last().Id;
        }


        /* Method adds application to the context */
        public void Add(Application application)
        {
            _ctx.Add(application);
            _ctx.SaveChanges();


        }



        /* Method updates Application givem status for give applicationId */
        public void SetApplicationStatus(int applicationId, string status)
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

        /* Method sets reason for rejection for given applicationId */
        public void SetSupervisorRejectionReason(int applicationId, string rejectReason)
        {
            Application app = _ctx.Applications.FirstOrDefault(a => a.Id == applicationId);
            app.SupervisorRejectReason = rejectReason;
            _ctx.SaveChanges();
        }

        /* Method allows PGC to either accepts or rejects a given applicationId */
        public void SetPGCApproval(int applicationId, string pgcApproval)
        {
            var application = _ctx.Applications
                        .FirstOrDefault(a => a.Id == applicationId);

            application.PGCApproval = pgcApproval;

            _ctx.SaveChanges();
        }
        /* Method sets PGC reason for rejection for given applicationId */
        public void SetPGCRejectionReason(int applicationId, string rejectReason)
        {
            Application app = _ctx.Applications.FirstOrDefault(a => a.Id == applicationId);
            app.PGCRejectReason = rejectReason;
            _ctx.SaveChanges();
        }

        /* Method retrieves all Applications pending PGC Approval" */
        public IEnumerable<Application> GetPGCReviewApplications()
        {
            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Include(a => a.Supervisor)
                       .Where(a => a.ApplicationStatus == "Pending_PGC_Approval");
        }
        /* Method retrieves all applications that are pending PGO review*/
        public IEnumerable<Application> GetReviewedApplications()
        {
            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Include(a => a.Supervisor)
                       .Where(a => a.ApplicationStatus == "Pending_PGO_Review");

        }

        /* Method retrieves all Applications assigned to a specific supervisor */
        public IEnumerable<Application> GetApplicationsForSupervisor(int supervisorId)
        {

            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Include(a => a.Supervisor)
                       .Where(a => a.Supervisor.Id == supervisorId && a.ApplicationStatus == "Pending_Supervisor_Approval");
        }
        /* This method returns all applications that are still in the application process from the db */
        public IEnumerable<Application> GetPendingApplications()
        {
            var pending_status = new List<string> { "Pending_Supervisor_Approval", "Pending_PGC_Approval" };
            return _ctx.Applications
                       .Include(a => a.Programme)
                       .Include(a => a.Supervisor)
                       .Where(a => pending_status.Contains(a.ApplicationStatus))
                       .OrderByDescending(a => a.ApplicationStatus);
        }
    }
}