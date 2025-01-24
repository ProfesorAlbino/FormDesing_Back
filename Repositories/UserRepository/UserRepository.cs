using FormDesing.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace FormDesing.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly FormDesingContext _context;


        public UserRepository(FormDesingContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddUser(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeleteUser(Guid id)
        {
            var usuario = await GetUserById(id);
            if (usuario == null) return null;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAllUser()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUserById(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> UpdateUser(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
