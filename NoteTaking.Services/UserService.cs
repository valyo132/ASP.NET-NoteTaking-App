using NoteTaking.Data;
using NoteTaking.Data.Common.Repositories;
using NoteTaking.Services.Interfaces;

namespace NoteTaking.Services
{
    public class UserService : UserRepositoy, IUserService
    {
        private readonly NoteTakingContext _context;

        public UserService(NoteTakingContext context) : base(context)
        {
            _context = context;
        }
    }
}
