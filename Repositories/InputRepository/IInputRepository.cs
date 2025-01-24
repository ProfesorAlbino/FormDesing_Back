using FormDesing.Models.DB;

namespace FormDesing.Repositories.InputRepository
{
    public interface IInputRepository
    {
        Task<TipoInput> GetInputById(Guid id);
        Task<IEnumerable<TipoInput>> GetAllInputs();
        Task<TipoInput> AddInput(TipoInput input);
        Task<TipoInput> UpdateInput(TipoInput input);
        Task<TipoInput> DeleteInput(Guid id);
    }
}
