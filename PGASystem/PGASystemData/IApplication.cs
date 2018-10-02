using System.Collections.Generic;
using System.Threading.Tasks;
using PGASystemData.Models;


namespace PGASystemData
{
    public interface IApplication
    {
        IEnumerable<ApplicationFiles> GetAllFiles(int applicationId);
        void Add(Application application);
        Application GetApplication(int applicationId);

        int GetLastApplicationId();


        IEnumerable<Application> GetReviewedApplications();

        void SetApplicationStatus(int applicationId, string status);

        void SetSupervisorApproval(int applicationId, string supervisorApproval);
        void SetSupervisorRejectionReason(int applicationId, string rejectReason);
        void SetPGCApproval(int applicationId, string pgcApproval);
        void SetPGCRejectionReason(int applicationId, string rejectReason);

        IEnumerable<Application> GetPGCReviewApplications();
        IEnumerable<Application> GetApplicationsForSupervisor(int supervisorId);




    }
}
