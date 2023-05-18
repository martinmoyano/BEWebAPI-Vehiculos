using System;
using System.Collections.Generic;

namespace BE_WebAPI_Vehiculos.Repository.Entities;

public partial class Ventum
{
    public int? Id { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdDetalle { get; set; }
}
