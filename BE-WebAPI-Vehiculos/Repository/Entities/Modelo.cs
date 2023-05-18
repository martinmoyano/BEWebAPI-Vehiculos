using System;
using System.Collections.Generic;

namespace BE_WebAPI_Vehiculos.Repository.Entities;

public partial class Modelo
{
    public int? Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdMarca { get; set; }
}
