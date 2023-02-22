using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            // User
            CreateMap<Data.Models.User, Dtos.User>();

            // Article
            CreateMap<Data.Models.Article, Dtos.Article>();
            CreateMap<Dtos.ArticleUpsert, Data.Models.Article>();
        }
    }
}
