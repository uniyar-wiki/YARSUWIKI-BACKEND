using YARSUWIKI.DOMAIN.Enum;

namespace YARSUWIKI.DOMAIN.Entity;

public class Author
{
    
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string TelegramLink { get; set; }
    
    public string Description { get; set; }
    
    public string PictureUrl { get; set; }
    
    public TypeAuthor TypeAuthor { get; set; }
    
}