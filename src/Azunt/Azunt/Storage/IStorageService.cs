using System.IO;
using System.Threading.Tasks;

namespace Azunt.Storage
{
    public interface IStorageService
    {
        Task<string> UploadAsync(Stream stream, string fileName);
        Task<Stream> DownloadAsync(string fileName);
        Task DeleteAsync(string fileName);
    }
}
