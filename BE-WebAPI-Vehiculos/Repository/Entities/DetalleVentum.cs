using System;
using System.Collections.Generic;

namespace BE_WebAPI_Vehiculos.Repository.Entities;

public partial class DetalleVentum
{
    public int? Id { get; set; }

    public int? IdVehiculo { get; set; }

    public int? Monto { get; set; }

    public int? Cantidad { get; set; }
}
