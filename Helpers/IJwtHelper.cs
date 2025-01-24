using FormDesing.Models.DB;

namespace FormDesing.Helpers
{
    public interface IJwtHelper
    {
        string GenerateToken(Usuario usuario);
        bool ValidateToken(string token);
    }
}
