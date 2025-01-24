using FormDesing.DTOs;

namespace FormDesing.Services.FormInputService
{
    public interface IFormInputService
    {
        Task<FormInputDTO> CreateFormInput(FormInputDTO formInput);
        Task<FormInputDTO> UpdateFormInput(FormInputDTO formInput);
        Task<FormInputDTO> DeleteFormInput(Guid id);
        Task<FormInputDTO> GetFormInputsById(Guid id);
        Task<IEnumerable<FormInputDTO>> getAllFormInputs();
        Task<IEnumerable<FormInputDTO>> getAllFormInputsByForm(Guid idForm);
    }
}
