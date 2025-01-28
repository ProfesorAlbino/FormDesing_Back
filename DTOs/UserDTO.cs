using FormDesing.Models.DB;

namespace FormDesing.DTOs
{
    public class UserDTO
    {
        public Guid IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Correo { get; set; }

        public string? Contraseña { get; set; }

        public string? Token { get; set; }
    }
}
