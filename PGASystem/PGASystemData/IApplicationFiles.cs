using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace PGASystemData
{
    public interface IApplicationFiles
    {
        CloudBlobContainer GetBlobContainer(string azureConnection, string containerName);
        Task SetFile(string title, Uri uri);
    }
}
