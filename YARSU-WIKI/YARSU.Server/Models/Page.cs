namespace YARSU.Server.Models
{
    public class Page
    {
        public Page()
        {
            Comments = new List<Comment>(); 
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public decimal Ratings { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
