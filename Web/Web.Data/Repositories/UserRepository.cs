using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Contexts;
using Web.Data.Models;

namespace Web.Data.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<bool> EmailExistsAsync(string email);

        Task<User> GetByEmailAsync(string email);
    }

    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(WebContext context) : base(context)
        {
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            return this.entities.AnyAsync(x => x.Email == email);
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
