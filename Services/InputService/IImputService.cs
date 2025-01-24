using FormDesing.DTOs;

namespace FormDesing.Services.InputService
{
    public interface IInputService
    {
        Task<InputDTO> CreateInput(InputDTO input);
        Task<InputDTO> UpdateInput(InputDTO input);
        Task<InputDTO> DeleteInput(Guid id);
        Task<InputDTO> GetInputsById(Guid id);
        Task<IEnumerable<InputDTO>> getAllInputs();
    }
}
