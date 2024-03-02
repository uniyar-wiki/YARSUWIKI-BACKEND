using Microsoft.AspNetCore.Mvc;
using YARSUWIKI.DAL;
using YARSUWIKI.DAL.Interfaces;
using YARSUWIKI.DOMAIN.Entity;
using YARSUWIKI.DOMAIN.ViewModels.User;
using YARSUWIKI.SERVICE.Interfaces;

namespace YARSUWIKI.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
        
    [HttpPost]
    public async Task<IActionResult> Save(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _userService.Create(model);
            if (response.StatusCode == DOMAIN.Enum.StatusCode.OK)
            {
                return Json(new { description = response.Description });
            }
            return BadRequest(new { errorMessage = response.Description });
        }

        var errorMessage = ModelState.Values
            .SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList();
        return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage });
    }
    
}