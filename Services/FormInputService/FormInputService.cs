using AutoMapper;
using FormDesing.DTOs;
using FormDesing.Models.DB;
using FormDesing.Repositories.FormInputRepository;

namespace FormDesing.Services.FormInputService
{
    public class FormInputService : IFormInputService
    {
        private readonly IMapper _mapper;
        private readonly IFormInputRepository _repository;
        public FormInputService(IMapper mapper, IFormInputRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<FormInputDTO> CreateFormInput(FormInputDTO formInput)
        {
            return _mapper.Map<FormInputDTO>(await _repository.AddFormInput(_mapper.Map<FormularioInput>(formInput)));
        }

        public async Task<FormInputDTO> DeleteFormInput(Guid id)
        {
            return _mapper.Map<FormInputDTO>(await _repository.DeleteFormInput(id));
        }

        public async Task<IEnumerable<FormInputDTO>> getAllFormInputs()
        {
            return _mapper.Map<IEnumerable<FormInputDTO>>(await _repository.GetAllFormInputs());
        }

        public async Task<FormInputDTO> GetFormInputsById(Guid id)
        {
            return _mapper.Map<FormInputDTO>(await _repository.GetFormInputById(id));
        }

        public async Task<IEnumerable<FormInputDTO>> getAllFormInputsByForm(Guid id)
        {
            return _mapper.Map<IEnumerable<FormInputDTO>>(await _repository.GetAllFormInputsByForm(id));
        }

        public async Task<FormInputDTO> UpdateFormInput(FormInputDTO formInput)
        {
            return _mapper.Map<FormInputDTO>(await _repository.UpdateFormInput(_mapper.Map<FormularioInput>(formInput)));
        }
    }
}
