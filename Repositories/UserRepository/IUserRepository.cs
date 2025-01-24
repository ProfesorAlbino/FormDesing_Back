using FormDesing.DTOs;
using FormDesing.Models.DB;

namespace FormDesing.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<Usuario> GetUserById(Guid id);
        Task<IEnumerable<Usuario>> GetAllUser();
        Task<Usuario> AddUser(Usuario usuario);
        Task<Usuario> UpdateUser(Usuario usuario);
        Task<Usuario> DeleteUser(Guid id);
    }
}
