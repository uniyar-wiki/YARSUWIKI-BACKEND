using System.ComponentModel.DataAnnotations;

namespace YARSUWIKI.DOMAIN.ViewModels.Account;

public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "Укажите email")]
    public string Email{ get; set; }
        
    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    
    public string NewPassword { get; set; }
}