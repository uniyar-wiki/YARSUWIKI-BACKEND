using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YARSUWIKI.DOMAIN.Response;

namespace YARSUWIKI.SERVICE.Interfaces
{
    public interface IStorageService
    {
        Task<BaseResponse<bool>> Download(string fileName);

        Task<BaseResponse<bool>> Upload(FileInfo file);
    }
}
