using FormDesing.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace FormDesing.Repositories.FormRepository
{
    public class FormRepository : IFormRepository
    {
        private readonly FormDesingContext _context;

        public FormRepository(FormDesingContext context)
        {
            _context = context;
        }

        public async Task<Formulario> AddForm(Formulario form)
        {
            await _context.Formularios.AddAsync(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<Formulario> DeleteForm(Guid id)
        {
            Formulario form = await GetFormById(id);
            if (form == null) return null;

            _context.Formularios.Remove(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public async Task<IEnumerable<Formulario>> GetAllFormByUser(Guid userId)
        {
            return await _context.Formularios.Where(form => form.IdUsuario == userId).ToListAsync();
        }

        public async Task<IEnumerable<Formulario>> GetAllForms()
        {
            return await _context.Formularios.ToListAsync();
        }

        public async Task<Formulario> GetFormById(Guid id)
        {
            return await _context.Formularios.FindAsync(id);
        }

        public async Task<IEnumerable<Formulario>> GetTopForms(int num, Guid idUsuario)
        {
            return await _context.Formularios
                .Where(form => form.IdUsuario.Equals(idUsuario))
                .OrderBy(form => form.FechaCreacion)
                .Take(num)
                .ToListAsync();
        }

        public async Task<int> TotalForms(Guid userId)
        {
            return await _context.Formularios
                .Where(f => f.IdUsuario.Equals(userId))
                .CountAsync();
        }

        public async Task<Formulario> UpdateForm(Formulario form)
        {
            _context.Formularios.Update(form);
            await _context.SaveChangesAsync();
            return form;
        }
    }
}
