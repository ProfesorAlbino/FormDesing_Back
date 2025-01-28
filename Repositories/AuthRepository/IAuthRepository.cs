using FormDesing.Models.DB;

namespace FormDesing.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        Task<Usuario> Login(string mail, string password);
    }
}
