using FormDesing.Models.DB;

namespace FormDesing.Repositories.FormDataRepository
{
    public interface IFormDataRepository
    {
        Task<DatoFormulario> GetFormDataById(Guid id);
        Task<IEnumerable<DatoFormulario>> GetAllFormDatas();
        Task<DatoFormulario> AddFormData(DatoFormulario formData);
        Task<DatoFormulario> UpdateFormData(DatoFormulario formData);
        Task<DatoFormulario> DeleteFormData(Guid id);
    }
}
