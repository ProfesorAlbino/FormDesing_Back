using FormDesing.DTOs;
using FormDesing.Helpers;
using FormDesing.Models;
using FormDesing.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace FormDesing.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {

        private readonly IJwtHelper _jwtHelper;
        private readonly IAuthService _service;

        public AuthController(IJwtHelper jwtHelper, IAuthService service)
        {
            _jwtHelper = jwtHelper;
            _service = service;
        }

        [HttpPost]
        public async Task<Response> Login([FromBody] AuthDTO auth)
        {
            try
            {
                UserDTO result= await _service.Login(auth.Mail, auth.Password);
                if (result == null) return new Response { Success = false, Data = "El usuario es incorrecto" };
                var token = _jwtHelper.GenerateToken(result);
                result.Token = token;
                return new Response
                {
                    Message = "Login correcto",
                    Data = result,
                    Success = true
                };
            }
            catch
            {
                return new Response { Success = false };
            }
        }
    }
}
