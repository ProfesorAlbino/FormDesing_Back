using System;
using System.Collections.Generic;

namespace FormDesing.Models.DB;

public partial class Formulario
{
    public Guid IdFormulario { get; set; }

    public Guid? IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<FormularioInput> FormularioInputs { get; set; } = new List<FormularioInput>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
