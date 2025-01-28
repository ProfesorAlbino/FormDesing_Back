using AutoMapper;
using FormDesing.DTOs;
using FormDesing.Repositories.AuthRepository;

namespace FormDesing.Services.AuthService
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _repository;
        private IMapper _mapper;

        public AuthService(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Login(string mail, string password)
        {
            return _mapper.Map<UserDTO>(await _repository.Login(mail, password));
        }
    }
}
