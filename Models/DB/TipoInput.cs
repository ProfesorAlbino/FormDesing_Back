using System;
using System.Collections.Generic;

namespace FormDesing.Models.DB;

public partial class TipoInput
{
    public Guid IdTipoInput { get; set; }

    public string? Nombre { get; set; }

    public string? Opciones { get; set; }

    public virtual ICollection<FormularioInput> FormularioInputs { get; set; } = new List<FormularioInput>();
}
