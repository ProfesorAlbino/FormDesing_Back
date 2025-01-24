using FormDesing.Models.DB;

namespace FormDesing.Repositories.FormInputRepository
{
    public interface IFormInputRepository
    {
        Task<FormularioInput> GetFormInputById(Guid id);
        Task<IEnumerable<FormularioInput>> GetAllFormInputs();
        Task<FormularioInput> AddFormInput(FormularioInput formInput);
        Task<FormularioInput> UpdateFormInput(FormularioInput formInput);
        Task<FormularioInput> DeleteFormInput(Guid id);
        Task<IEnumerable<FormularioInput>> GetAllFormInputsByForm(Guid idForm);
    }
}
