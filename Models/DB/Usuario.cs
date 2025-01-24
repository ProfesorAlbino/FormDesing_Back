using System;
using System.Collections.Generic;

namespace FormDesing.Models.DB;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<Formulario> Formularios { get; set; } = new List<Formulario>();
}
