using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Contexts;
using Web.Data.Models;

namespace Web.Data.Repositories
{
    public interface IArticleRepository : IRepository<Article, int>
    {
    }

    public class ArticleRepository : DatabaseRepository<Article, int>, IArticleRepository
    {
        public ArticleRepository(WebContext context) : base(context, article => article.User)
        {
        }        
    }
}
