using NoteTaking.Data.Models;

namespace NoteTaking.Data.Common.Repositories.IRepositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get the current logged in user by it's ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApplicationUser GetUserById(string id);
    }
}
