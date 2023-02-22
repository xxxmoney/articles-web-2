using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Dtos
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
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
}
