using FormDesing.DTOs;
using FormDesing.Models;
using FormDesing.Services.FormDataService;
using Microsoft.AspNetCore.Mvc;

namespace FormDesing.Controllers
{
    [ApiController]
    [Route("formdata")]
    public class FormDataController : Controller
    {
        private readonly IFormaDataService _service;

        public FormDataController(IFormaDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Response> GetAllFormDatas()
        {
            try
            {
                IEnumerable<FormDataDTO> result = await _service.getAllFormDatas();
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Success = true, Message = "", Data = result };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetFormDataById")]
        public async Task<Response> GetFormDataById(Guid id)
        {
            try
            {
                FormDataDTO result = await _service.GetFormDataById(id);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetFormDataByUser")]
        public async Task<Response> GetFormDataByUser(Guid idUser)
        {
            try
            {
                int result = await _service.GetDataByUser(idUser);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpPost]
        public async Task<Response> AddFormData([FromBody] FormDataDTO formDataDTO)
        {
            try
            {
                FormDataDTO result = await _service.CreateFormData(formDataDTO);
                if (result == null) return new Response { Success = false, Message = "" };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response() { Success = false };
            }
        }

        [HttpPut]
        public async Task<Response> UpdateFormData([FromBody] FormDataDTO formData)
        {
            try
            {
                FormDataDTO result = await _service.UpdateFormData(formData);
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpDelete]
        public async Task<Response> DeleteFormInput(Guid id)
        {
            try
            {
                FormDataDTO result = await _service.DeleteFormData(id);
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Success = true, Message = "", Data = result };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetFormDataByForm")]
        public async Task<Response> GetFormDataByForm(Guid idForm)
        {
            try
            {
                IEnumerable<FormDataDTO> result = await _service.GetAllDataByForm(idForm);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

    }
}
