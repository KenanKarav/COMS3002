using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using PGASystemData.Models;

namespace PGASystemData
{
    public interface IApplicationFiles
    {
        CloudBlobContainer GetBlobContainer(string azureConnection, string containerName);
        Task SetFile(string title, Uri uri);
         IEnumerable<ApplicationFiles> getFilesForApplication(int applicationId);
    }
}
