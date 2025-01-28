using FormDesing.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace FormDesing.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FormDesingContext _context;

        public AuthRepository (FormDesingContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Login(string mail, string password)
        {
            return await _context.Usuarios
                .Where(u => u.Correo.Equals(mail) && u.Contraseña.Equals(password))
                .FirstOrDefaultAsync();
        }
    }
}
