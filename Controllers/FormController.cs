using FormDesing.DTOs;
using FormDesing.Models;
using FormDesing.Services.FormService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormDesing.Controllers
{
    [ApiController]
    [Route("form")]
    
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<Response> GetAllForms()
        {
            try
            {
               IEnumerable<FormDTO> result = await _formService.getAllForms();
                if(result==null) return new Response { Message="", Success=false };
                return new Response { Success = true, Message = "", Data = result };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetFormById")]
        public async Task<Response> GetFormById(Guid id)
        {
            try
            {
                FormDTO result = await _formService.GetFormsById(id);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetFormByUser")]
        public async Task<Response> GetFormByUser(Guid idUser)
        {
            try
            {
                IEnumerable<FormDTO> result = await _formService.GetAllFormByUser(idUser);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetTotalForms")]
        public async Task<Response> GetTotalForms(Guid idUser)
        {
            try
            {
                int result = await _formService.TotalForms(idUser);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetTopForms")]
        public async Task<Response> GetTopForms(int num, Guid idUsuario)
        {
            try
            {
                IEnumerable<FormDTO> result = await _formService.GetTopForms(num, idUsuario);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response { Data = result, Message = "", Success = true };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpPost]
        public async Task<Response> AddForm([FromBody] FormDTO formDTO)
        {
            try
            {
                FormDTO result = await _formService.CreateForm(formDTO);
                if (result == null) return new Response { Success = false, Message = "" };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response() { Success = false };
            }
        }

        [HttpPut]
        public async Task<Response> UpdateUser([FromBody] FormDTO form)
        {
            try
            {
                FormDTO result = await _formService.UpdateForm(form);
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpDelete]
        public async Task<Response> DeleteForm(Guid id)
        {
            try
            {
                FormDTO result = await _formService.DeleteForm(id);
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
