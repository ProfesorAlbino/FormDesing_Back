using FormDesing.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace FormDesing.Repositories.InputRepository
{
    public class InputRepository : IInputRepository
    {
        private readonly FormDesingContext _context;

        public InputRepository(FormDesingContext context)
        {
            _context = context;
        }

        public async Task<TipoInput> AddInput(TipoInput input)
        {
            await _context.TipoInputs.AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<TipoInput> DeleteInput(Guid id)
        {
            TipoInput input = await GetInputById(id);
            if (input == null) return null;

            _context.TipoInputs.Remove(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<IEnumerable<TipoInput>> GetAllInputs()
        {
            return await _context.TipoInputs.ToListAsync();
        }

        public async Task<TipoInput> GetInputById(Guid id)
        {
            return await _context.TipoInputs.FindAsync(id);
        }

        public async Task<TipoInput> UpdateInput(TipoInput input)
        {
            _context.TipoInputs.Update(input);
            await _context.SaveChangesAsync();
            return input;
        }
    }
}
