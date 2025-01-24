using AutoMapper;
using FormDesing.DTOs;
using FormDesing.Models.DB;
using FormDesing.Repositories.FormDataRepository;

namespace FormDesing.Services.FormDataService
{
    public class FormDataService : IFormaDataService
    {
        private readonly IFormDataRepository _repository;
        private readonly IMapper _mapper;

        public FormDataService(IFormDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FormDataDTO> CreateFormData(FormDataDTO formData)
        {
            return _mapper.Map<FormDataDTO>(await _repository.AddFormData(_mapper.Map<DatoFormulario>(formData)));
        }

        public async Task<FormDataDTO> DeleteFormData(Guid id)
        {
            return _mapper.Map<FormDataDTO>(await _repository.DeleteFormData(id));
        }

        public async Task<IEnumerable<FormDataDTO>> getAllFormDatas()
        {
            return _mapper.Map<IEnumerable<FormDataDTO>>(await _repository.GetAllFormDatas());
        }

        public async Task<FormDataDTO> GetFormDataById(Guid id)
        {
            return _mapper.Map<FormDataDTO>(await _repository.GetFormDataById(id));
        }

        public async Task<FormDataDTO> UpdateFormData(FormDataDTO formData)
        {
            return _mapper.Map<FormDataDTO>(await _repository.UpdateFormData(_mapper.Map<DatoFormulario>(formData)));
        }
    }
}
