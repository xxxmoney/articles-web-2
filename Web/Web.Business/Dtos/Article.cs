namespace Web.Business.Dtos
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PictureName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
    }

    public class ArticleFilter
    {
        public int? UserId { get; set; }
    }

    public class ArticleUpsert
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class ArticlePictureUpload
    {
        public int ArticleId { get; set; }
        public string PictureBase64 { get; set; }
    }
}
