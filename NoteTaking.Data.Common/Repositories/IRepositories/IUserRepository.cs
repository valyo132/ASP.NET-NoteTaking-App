using NoteTaking.Data.Models;

namespace NoteTaking.Data.Common.Repositories.IRepositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUserById(string id);
    }
}
