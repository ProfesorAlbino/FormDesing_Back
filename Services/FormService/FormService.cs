using AutoMapper;
using FormDesing.DTOs;
using FormDesing.Models.DB;
using FormDesing.Repositories.FormRepository;

namespace FormDesing.Services.FormService
{
    public class FormService : IFormService
    {

        private readonly IMapper _mapper;
        private readonly IFormRepository _formRepository;

        public FormService(IMapper mapper, IFormRepository repository)
        {
            _mapper = mapper;
            _formRepository = repository;
        }

        public async Task<FormDTO> CreateForm(FormDTO form)
        {
            return _mapper.Map<FormDTO>(await _formRepository.AddForm(_mapper.Map<Formulario>(form)));
        }

        public async Task<FormDTO> DeleteForm(Guid id)
        {
            return _mapper.Map<FormDTO>(await _formRepository.DeleteForm(id));
        }

        public async Task<IEnumerable<FormDTO>> GetAllFormByUser(Guid userId)
        {
            return _mapper.Map<IEnumerable<FormDTO>>(await _formRepository.GetAllFormByUser(userId));
        }

        public async Task<IEnumerable<FormDTO>> getAllForms()
        {
            return _mapper.Map<IEnumerable<FormDTO>>(await _formRepository.GetAllForms());
        }

        public async Task<FormDTO> GetFormsById(Guid id)
        {
            return _mapper.Map<FormDTO>(await _formRepository.GetFormById(id));
        }

        public async Task<IEnumerable<FormDTO>> GetTopForms(int num, Guid idUser)
        {
            return _mapper.Map<IEnumerable<FormDTO>>(await _formRepository.GetTopForms(num, idUser));
        }

        public async Task<int> TotalForms(Guid userId)
        {
            return await _formRepository.TotalForms(userId);
        }

        public async Task<FormDTO> UpdateForm(FormDTO form)
        {
            return _mapper.Map<FormDTO>(await _formRepository.UpdateForm(_mapper.Map<Formulario>(form)));
        }
    }
}
