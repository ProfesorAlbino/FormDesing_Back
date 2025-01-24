using FormDesing.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace FormDesing.Repositories.FormInputRepository
{
    public class FormInputRepository : IFormInputRepository
    {
        private readonly FormDesingContext _context;

        public FormInputRepository(FormDesingContext context)
        {
            _context = context;
        }

        public async Task<FormularioInput> AddFormInput(FormularioInput formInput)
        {
            await _context.FormularioInputs.AddAsync(formInput);
            await _context.SaveChangesAsync();
            return formInput;
        }

        public async Task<FormularioInput> DeleteFormInput(Guid id)
        {
            FormularioInput formInput = await GetFormInputById(id);
            if (formInput == null) return null;

            _context.FormularioInputs.Remove(formInput);
            await _context.SaveChangesAsync();
            return formInput;
        }

        public async Task<IEnumerable<FormularioInput>> GetAllFormInputs()
        {
            return await _context.FormularioInputs.ToListAsync();
        }

        public async Task<IEnumerable<FormularioInput>> GetAllFormInputsByForm(Guid idForm)
        {
            return await _context.FormularioInputs
                .Where(formInput => formInput.IdFormulario == idForm)
                .ToListAsync();
        }

        public async Task<FormularioInput> GetFormInputById(Guid id)
        {
            return await _context.FormularioInputs.FindAsync(id);
        }

        public async Task<FormularioInput> UpdateFormInput(FormularioInput formInput)
        {
            _context.FormularioInputs.Update(formInput);
            await _context.SaveChangesAsync();
            return formInput;
        }
    }
}
