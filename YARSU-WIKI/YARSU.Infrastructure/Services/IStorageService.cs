using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YARSU.Infrastructure.Services
{
    public interface IStorageService
    {
        Task<bool> Download(string fileName);

        Task<bool> Upload(FileInfo file);
    }
}
