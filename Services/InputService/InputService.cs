using AutoMapper;
using FormDesing.DTOs;
using FormDesing.Models.DB;
using FormDesing.Repositories.InputRepository;

namespace FormDesing.Services.InputService
{
    public class InputService : IInputService
    {
        private readonly IInputRepository _inputRepository;
        private readonly IMapper _mapper;

        public InputService(IInputRepository inputRepository, IMapper mapper)
        {
            _inputRepository = inputRepository;
            _mapper = mapper;
        }

        public async Task<InputDTO> CreateInput(InputDTO input)
        {
            return _mapper.Map<InputDTO>(await _inputRepository.AddInput(_mapper.Map<TipoInput>(input)));
        }

        public async Task<InputDTO> DeleteInput(Guid id)
        {
            return _mapper.Map<InputDTO>(await _inputRepository.DeleteInput(id));
        }

        public async Task<IEnumerable<InputDTO>> getAllInputs()
        {
            return _mapper.Map<IEnumerable<InputDTO>>(await _inputRepository.GetAllInputs());
        }

        public async Task<InputDTO> GetInputsById(Guid id)
        {
            return _mapper.Map<InputDTO>(await _inputRepository.GetInputById(id));
        }

        public async Task<InputDTO> UpdateInput(InputDTO input)
        {
            return _mapper.Map<InputDTO>(await _inputRepository.UpdateInput(_mapper.Map<TipoInput>(input)));
        }
    }
}
