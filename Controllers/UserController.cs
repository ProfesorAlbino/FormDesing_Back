using FormDesing.DTOs;
using FormDesing.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using FormDesing.Models;

namespace FormDesing.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<Response> GetUsers()
        {
            try
            {
                IEnumerable<UserDTO> result = await _userService.getAllUsers();
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
                return new Response {Success = false };
            }
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<Response> GetUserById(Guid id)
        {
            try
            {
                UserDTO result = await _userService.GetUserById(id);
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
        public async Task<Response> AddUser([FromBody] UserDTO userDTO)
        {
            try
            {
                if(userDTO.Apellido==null || userDTO.Nombre==null) return new Response { Success = false, Message = "" };
                if(userDTO.Correo==null || userDTO.Contraseña==null) return new Response { Success = false, Message = "" };

                UserDTO result = await _userService.CreateUser(userDTO);
                if (result == null) return new Response { Success = false, Message = "" };
                return new Response { Data = result, Success = true, Message="" };
            }
            catch
            {
                return new Response() { Success = false };
            }
        }

        [HttpPut]
        public async Task<Response> UpdateUser([FromBody] UserDTO user)
        {
            try
            {
                UserDTO result = await _userService.UpdateUser(user);
                if (result == null) return new Response { Message = "", Success = false };
                return new Response { Data = result, Success = true, Message = "" };
            }
            catch
            {
                return new Response { Success = false };
            }
        }

        [HttpDelete]
        public async Task<Response> DeleteUser(Guid id)
        {
            try
            {
                UserDTO result = await _userService.DeleteUser(id);
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
