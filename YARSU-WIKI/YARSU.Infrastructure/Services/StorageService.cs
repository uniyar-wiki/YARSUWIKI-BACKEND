using System.IO;
using System.Threading.Tasks;

namespace YARSU.Infrastructure.Services
{
    public class StorageService : IStorageService
    {
        public Task<bool> Download(string fileName)
        {
            var filePath = Path.Combine("../storage", fileName);
            var exists = File.Exists(filePath);
            return Task.FromResult(exists);
        }

        public Task<bool> Upload(FileInfo file)
        {
            try
            {
                var destinationPath = Path.Combine("../storage", file.Name);
                file.CopyTo(destinationPath, true);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
