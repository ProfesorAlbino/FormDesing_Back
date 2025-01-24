using FormDesing.DTOs;
using FormDesing.Models;
using FormDesing.Services.InputService;
using Microsoft.AspNetCore.Mvc;

namespace FormDesing.Controllers
{
    [ApiController]
    [Route("input")]
    public class InputController : Controller
    {
        private readonly IInputService _inputService;

        public InputController(IInputService inputService) 
        {
            this._inputService = inputService;
        }

        [HttpGet]
        public async Task<Response> GetInputs()
        {
            try
            {
                IEnumerable<InputDTO> result = await _inputService.getAllInputs();
                if (result == null) return new Response { Message = "", Success = false };

                return new Response
                {
                    Data = result,
                    Message = "",
                    Success = true
                };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpGet]
        [Route("GetInputById")]
        public async Task<Response> GetInputById(Guid id)
        {
            try
            {
                InputDTO result = await _inputService.GetInputsById(id);
                if (result == null) return new Response { Message = "", Success = false };

                return new Response
                {
                    Data = result,
                    Message = "",
                    Success = true
                };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpPost]
        public async Task<Response> AddInputr(InputDTO inputDTO)
        {
            try
            {
                InputDTO result = await _inputService.CreateInput(inputDTO);
                if (result == null) return new Response { Success = false, Message = "" };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response() { Success = false };
            }
        }

        [HttpPut]
        public async Task<Response> UpdateUser(InputDTO input)
        {
            try
            {
                InputDTO result = await _inputService.UpdateInput(input);
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpDelete]
        public async Task<Response> DeleteInput(Guid id)
        {
            try
            {
                InputDTO result = await _inputService.DeleteInput(id);
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
