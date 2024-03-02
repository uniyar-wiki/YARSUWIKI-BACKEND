using System.ComponentModel.DataAnnotations;

namespace YARSUWIKI.DOMAIN.ViewModels.User;

public class UserViewModel
{
    [Display(Name = "Id")]
    public long Id { get; set; }
        
    [Required(ErrorMessage = "Укажите email")]
    [Display(Name = "email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Укажите пароль")]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
}