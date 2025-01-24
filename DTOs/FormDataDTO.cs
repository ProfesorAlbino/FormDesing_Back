namespace FormDesing.DTOs
{
    public class FormDataDTO
    {
        public Guid IdDatoFormulario { get; set; }

        public Guid? IdFormularioInput { get; set; }

        public string? Valor { get; set; }

        public DateTime? FechaIngreso { get; set; }
    }
}
