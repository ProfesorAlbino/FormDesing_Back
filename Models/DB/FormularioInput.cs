using System;
using System.Collections.Generic;

namespace FormDesing.Models.DB;

public partial class FormularioInput
{
    public Guid IdFormularioInput { get; set; }

    public Guid? IdFormulario { get; set; }

    public Guid? IdTipoInput { get; set; }

    public string? NombreInput { get; set; }

    public string? Etiqueta { get; set; }

    public int? Orden { get; set; }

    public virtual ICollection<DatoFormulario> DatoFormularios { get; set; } = new List<DatoFormulario>();

    public virtual Formulario? IdFormularioNavigation { get; set; }

    public virtual TipoInput? IdTipoInputNavigation { get; set; }
}
