using Azure.Messaging;
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

        public async Task<IEnumerable<DatoFormulario>> GetAllDataByForm(Guid id)
        {
            IEnumerable<DatoFormulario> formData = await _context.DatoFormularios
                .Include(formData => formData.IdFormularioInputNavigation)
                .ThenInclude(formInput => formInput.IdFormularioNavigation)
                .Where(formInput=> formInput.IdFormularioInputNavigation.IdFormulario == id)
                .OrderBy(formData => formData.FechaIngreso)
                .ToListAsync();

            if (formData == null) return null;
            return formData;
        }

        public async Task<IEnumerable<DatoFormulario>> GetAllFormDatas()
        {
            return await _context.DatoFormularios.ToListAsync();
        }

        public async Task<int> GetDataByUser(Guid idUser)
        {
            return await _context.DatoFormularios
                .Include(dataForm => dataForm.IdFormularioInputNavigation)
                .ThenInclude(formInput => formInput.IdFormularioNavigation)
                .ThenInclude(form => form.IdUsuarioNavigation)
                .Where(dataForm => dataForm.IdFormularioInputNavigation.IdFormularioNavigation.IdUsuarioNavigation.IdUsuario.Equals(idUser))
                .CountAsync();
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
