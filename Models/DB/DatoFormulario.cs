using System;
using System.Collections.Generic;

namespace FormDesing.Models.DB;

public partial class DatoFormulario
{
    public Guid IdDatoFormulario { get; set; }

    public Guid? IdFormularioInput { get; set; }

    public string? Valor { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public virtual FormularioInput? IdFormularioInputNavigation { get; set; }
}
