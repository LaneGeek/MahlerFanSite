namespace MahlerFanSite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public Story RevStory { get; set; }
    }
}
