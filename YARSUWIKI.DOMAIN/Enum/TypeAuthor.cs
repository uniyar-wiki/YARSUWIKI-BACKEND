using System.ComponentModel.DataAnnotations;

namespace YARSUWIKI.DOMAIN.Enum;

public enum TypeAuthor
{
    [Display(Name = "Бэкэндер")]
    Backend = 0,
    [Display(Name = "Фронтэндер")]
    Frontend = 1
}