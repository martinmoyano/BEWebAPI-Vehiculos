namespace BE_WebAPI_Vehiculos.Common.Models
{
    public class Vehiculo
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
