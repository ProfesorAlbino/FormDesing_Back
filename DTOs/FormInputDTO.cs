namespace FormDesing.DTOs
{
    public class FormInputDTO
    {
        public Guid IdFormularioInput { get; set; }

        public Guid? IdFormulario { get; set; }

        public Guid? IdTipoInput { get; set; }

        public string? NombreInput { get; set; }

        public string? Etiqueta { get; set; }

        public int? Orden { get; set; }
    }
}
