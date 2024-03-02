using System.ComponentModel.DataAnnotations;

namespace YARSUWIKI.DOMAIN.ViewModels.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Укажите email")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    public string Password { get; set; }
}