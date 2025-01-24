using AutoMapper;
using FormDesing.DTOs;
using FormDesing.Models.DB;
using FormDesing.Repositories.UserRepository;

namespace FormDesing.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            return _mapper.Map<UserDTO>(await _userRepository.AddUser(_mapper.Map<Usuario>(user)));
        }

        public async Task<UserDTO> DeleteUser(Guid idUser)
        {
            return _mapper.Map<UserDTO>( await _userRepository.DeleteUser(idUser));
        }

        public async Task<IEnumerable<UserDTO>> getAllUsers()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _userRepository.GetAllUser());
        }

        public async Task<UserDTO> GetUserById(Guid idUser)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetUserById(idUser));
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            return _mapper.Map<UserDTO>(await _userRepository.UpdateUser(_mapper.Map<Usuario>(user)));
        }
    }
}
