namespace Gifter.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int PostId { get; set; }
        public string Message { get; set; }
    }
}