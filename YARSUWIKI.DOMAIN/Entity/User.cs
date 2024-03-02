namespace YARSUWIKI.DOMAIN.Entity;

public class User
{
    public long Id { get; set; }
    
    public string Email { get; set; }
    
    public string? Password { get; set; }
    
    public string? FirstName  { get; set; }
    
    public string? LastName { get; set; }
    
    public int CourseNum { get; set; }
    
    public string? Group { get; set; }
    
    public string? PictureUrl { get; set; }
    
    public bool? isVerified { get; set; }
    
}