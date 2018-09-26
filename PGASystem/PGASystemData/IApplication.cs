using System.Collections.Generic;
using System.Threading.Tasks;
using PGASystemData.Models;


namespace PGASystemData
{
    public interface IApplication
    {
        IEnumerable<ApplicationFiles> GetAllFiles(int applicationId);
        Task Add(Application application);
       
    }
}
