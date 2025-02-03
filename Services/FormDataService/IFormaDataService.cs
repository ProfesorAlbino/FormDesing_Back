using FormDesing.DTOs;

namespace FormDesing.Services.FormDataService
{
    public interface IFormaDataService
    {
        Task<FormDataDTO> CreateFormData(FormDataDTO formData);
        Task<FormDataDTO> UpdateFormData(FormDataDTO formData);
        Task<FormDataDTO> DeleteFormData(Guid id);
        Task<FormDataDTO> GetFormDataById(Guid id);
        Task<IEnumerable<FormDataDTO>> getAllFormDatas();
        Task<IEnumerable<FormDataDTO>> GetAllDataByForm(Guid id);
        Task<int> GetDataByUser(Guid idUser);
    }
}
