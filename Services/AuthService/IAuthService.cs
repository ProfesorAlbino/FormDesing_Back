using FormDesing.DTOs;

namespace FormDesing.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserDTO> Login(string mail, string password);
    }
}
