using System.ComponentModel.DataAnnotations;

namespace YARSUWIKI.DOMAIN.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "Введите email")]
    [Display(Name = "email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    [Display(Name = "пароль")]
    public string Password { get; set; }
}