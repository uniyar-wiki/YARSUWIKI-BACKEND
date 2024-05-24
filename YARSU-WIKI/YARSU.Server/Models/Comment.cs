namespace YARSU.Server.Models
{
    public class Comment
    {
        public Comment()
        {
            User = new User();
        }
        public int Id { get; set; }

        public int PageId { get; set; } 

        public User User { get; set; }

        public string Content { get; set; }

        public decimal Rating { get; set; }
    }
}
