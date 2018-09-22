using System;
using System.Collections.Generic;

using PGASystemData.Models;


namespace PGASystemData
{
    public interface IApplication
    {
        IEnumerable<ApplicationFiles> GetAllFiles(int applicationId);
       
    }
}
