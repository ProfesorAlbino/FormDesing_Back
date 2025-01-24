namespace FormDesing.DTOs
{
    public class FormDTO
    {
        public Guid IdFormulario { get; set; }

        public Guid? IdUsuario { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
