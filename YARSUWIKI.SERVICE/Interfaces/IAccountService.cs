using System.Security.Claims;
using YARSUWIKI.DOMAIN.Response;
using YARSUWIKI.DOMAIN.ViewModels.Account;

namespace YARSUWIKI.SERVICE.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

    Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

    Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
}