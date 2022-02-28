using System;
namespace MyFirstWebApplication.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string TopicId { get; set; }
    }
    
}
