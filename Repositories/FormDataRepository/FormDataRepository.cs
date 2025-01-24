using FormDesing.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace FormDesing.Repositories.FormDataRepository
{
    public class FormDataRepository : IFormDataRepository
    {
        private readonly FormDesingContext _context;

        public FormDataRepository(FormDesingContext context)
        {
            _context = context;
        }

        public async Task<DatoFormulario> AddFormData(DatoFormulario formData)
        {
            await _context.DatoFormularios.AddAsync(formData);
            await _context.SaveChangesAsync();
            return formData;
        }

        public async Task<DatoFormulario> DeleteFormData(Guid id)
        {
            DatoFormulario formData = await GetFormDataById(id);
            if (formData == null) return null;

            _context.DatoFormularios.Remove(formData);
            await _context.SaveChangesAsync();
            return formData;
        }

        public async Task<IEnumerable<DatoFormulario>> GetAllFormDatas()
        {
            return await _context.DatoFormularios.ToListAsync();
        }

        public async Task<DatoFormulario> GetFormDataById(Guid id)
        {
            return await _context.DatoFormularios.FindAsync(id);
        }

        public async Task<DatoFormulario> UpdateFormData(DatoFormulario formData)
        {
            _context.DatoFormularios.Update(formData);
            await _context.SaveChangesAsync();
            return formData;
        }
    }
}
