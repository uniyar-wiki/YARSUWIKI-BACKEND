using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YARSUWIKI.DAL.Interfaces;
using YARSUWIKI.DOMAIN.Entity;
using YARSUWIKI.DOMAIN.Enum;
using YARSUWIKI.DOMAIN.Response;
using YARSUWIKI.DOMAIN.Utils;
using YARSUWIKI.DOMAIN.ViewModels.User;
using YARSUWIKI.SERVICE.Interfaces;

namespace YARSUWIKI.SERVICE.Implementations;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IBaseRepository<User> _userRepository;

    public UserService(ILogger<UserService> logger, IBaseRepository<User> userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task<IBaseResponse<User>> Create(UserViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user != null)
            {
                return new BaseResponse<User>()
                {
                    Description = "Пользователь с такой почтой уже есть",
                    StatusCode = StatusCode.UserAlreadyExists
                };
            }
            user = new User()
            {
                Email = model.Email,
                Password = Hasher.PasswordHash(model.Password),
            };
            
            await _userRepository.Create(user);
            
            return new BaseResponse<User>()
            {
                Data = user,
                Description = "Пользователь добавлен",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[UserService.Create] error: {ex.Message}");
            return new BaseResponse<User>()
            {
                StatusCode = StatusCode.InternalServerError,
                Description = $"Внутренняя ошибка: {ex.Message}"
            };
        }
    }
    
    public async Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
    {
        try
        {
            var users = await _userRepository.GetAll()
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    Email = x.Email,
                })
                .ToListAsync();

            _logger.LogInformation($"[UserService.GetUsers] получено элементов {users.Count}");
            return new BaseResponse<IEnumerable<UserViewModel>>()
            {
                Data = users,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[UserSerivce.GetUsers] error: {ex.Message}");
            return new BaseResponse<IEnumerable<UserViewModel>>()
            {
                StatusCode = StatusCode.InternalServerError,
                Description = $"Внутренняя ошибка: {ex.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteUser(long id)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.UserNotFound,
                    Data = false
                };
            }
            await _userRepository.Delete(user);
            _logger.LogInformation($"[UserService.DeleteUser] пользователь удален");
            
            return new BaseResponse<bool>
            {
                StatusCode = StatusCode.OK,
                Data = true
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[UserSerivce.DeleteUser] error: {ex.Message}");
            return new BaseResponse<bool>()
            {
                StatusCode = StatusCode.InternalServerError,
                Description = $"Внутренняя ошибка: {ex.Message}"
            };
        }
    }
}