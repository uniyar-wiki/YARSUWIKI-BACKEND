using YARSUWIKI.DOMAIN.Entity;
using YARSUWIKI.DOMAIN.Response;
using YARSUWIKI.DOMAIN.ViewModels.User;

namespace YARSUWIKI.SERVICE.Interfaces;

public interface IUserService
{
    
    Task<IBaseResponse<User>> Create(UserViewModel model);

    Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

    Task<IBaseResponse<bool>> DeleteUser(long id);
        
}