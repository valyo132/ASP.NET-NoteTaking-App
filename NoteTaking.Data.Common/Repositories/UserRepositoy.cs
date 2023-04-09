using Microsoft.EntityFrameworkCore;
using NoteTaking.Data.Common.Repositories.IRepositories;
using NoteTaking.Data.Models;

namespace NoteTaking.Data.Common.Repositories
{
    public class UserRepositoy : IUserRepository
    {
        private readonly NoteTakingContext _context;

        public UserRepositoy(NoteTakingContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserById(string id)
            => _context.ApplicationUsers.Include(u => u.Notes).FirstOrDefault(user => user.Id == id);
    }
}
