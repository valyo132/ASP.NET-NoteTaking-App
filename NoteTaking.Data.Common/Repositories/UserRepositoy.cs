using Microsoft.EntityFrameworkCore;
using NoteTaking.Data.Common.Repositories.IRepositories;
using NoteTaking.Data.Models;

namespace NoteTaking.Data.Common.Repositories
{
    public class UserRepositoy : IUserRepository
    {
        /// <summary>
        /// An instance of NoteTakingContext
        /// </summary>
        private readonly NoteTakingContext _context;

        public UserRepositoy(NoteTakingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the current logged in user by it's ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApplicationUser GetUserById(string id)
            => _context.ApplicationUsers.Include(u => u.Notes).FirstOrDefault(user => user.Id == id);
    }
}
