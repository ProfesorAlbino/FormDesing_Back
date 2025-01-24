using FormDesing.DTOs;

namespace FormDesing.Services.UserService
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(UserDTO user);
        Task<UserDTO> UpdateUser(UserDTO user);
        Task<UserDTO> DeleteUser(Guid idUser);
        Task<UserDTO> GetUserById(Guid idUser);
        Task<IEnumerable<UserDTO>> getAllUsers();
    }
}
