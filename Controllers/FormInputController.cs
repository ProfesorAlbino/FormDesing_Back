using FormDesing.DTOs;
using FormDesing.Models;
using FormDesing.Services.FormInputService;
using Microsoft.AspNetCore.Mvc;

namespace FormDesing.Controllers
{
    [ApiController]
    [Route("forminput")]
    public class FormInputController : Controller
    {
        private readonly IFormInputService _service;

        public FormInputController(IFormInputService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<Response> GetAllFormsInputs()
        {
            try
            {
                IEnumerable<FormInputDTO> result = await _service.getAllFormInputs();
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Success = true, Message = "", Data = result };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetFormInputById")]
        public async Task<Response> GetFormInputById(Guid id)
        {
            try
            {
                FormInputDTO result = await _service.GetFormInputsById(id);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }
        [HttpGet]
        [Route("GetFormInputsByForm")]
        public async Task<Response> GetFormInputByForm(Guid idForm)
        {
            try
            {
                IEnumerable<FormInputDTO> result = await _service.getAllFormInputsByForm(idForm);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpPost]
        public async Task<Response> AddFormInput(FormInputDTO formInputDTO)
        {
            try
            {
                FormInputDTO result = await _service.CreateFormInput(formInputDTO);
                if (result == null) return new Response { Success = false, Message = "" };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response() { Success = false };
            }
        }

        [HttpPut]
        public async Task<Response> UpdateFormInput(FormInputDTO formInput)
        {
            try
            {
                FormInputDTO result = await _service.UpdateFormInput(formInput);
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
                FormInputDTO result = await _service.DeleteFormInput(id);
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Success = true, Message = "", Data = result };
            }
            catch
            {
                return new Response { Success = false };
            }
        }
    }
}
