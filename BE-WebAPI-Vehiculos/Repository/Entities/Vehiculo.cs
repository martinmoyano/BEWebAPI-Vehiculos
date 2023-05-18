using System;
using System.Collections.Generic;

namespace BE_WebAPI_Vehiculos.Repository.Entities;

public partial class Vehiculo
{
    public int Id { get; set; }

    public string? Patente { get; set; }

    public int? IdTipo { get; set; }

    public int? IdModelo { get; set; }

    public string? Combustible { get; set; }

    public int? Stock { get; set; }

    public DateTime? Fecha { get; set; }
}
