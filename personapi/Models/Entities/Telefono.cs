using System;
using System.Collections.Generic;

namespace personapi_dotnet.Models.Entities;

public partial class Telefono
{
    public string Num { get; set; } = null!;

    public string? Oper { get; set; }

    public int? Duenio { get; set; }

    // Relación con la entidad Persona
    public virtual Persona? Persona { get; set; }
}
