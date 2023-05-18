using BE_WebAPI_Vehiculos.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace BE_WebAPI_Vehiculos.Common.Dtos
{
    public class VehiculoDto
    {
        public int Id { get; set; }
        public string? Patente { get; set; }        
        public string? Combustible { get; set; }
        public int? Stock { get; set; }
        public TipoVehiculo Tipo { get; set; }
        public Modelo ModeloVehiculo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
