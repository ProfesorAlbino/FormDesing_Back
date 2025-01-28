using FormDesing.DTOs;

namespace FormDesing.Helpers
{
    public interface IJwtHelper
    {
        string GenerateToken(UserDTO usuario);
        bool ValidateToken(string token);
    }
}
