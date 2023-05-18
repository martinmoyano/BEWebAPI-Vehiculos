namespace BE_WebAPI_Vehiculos.Repository.Entities.Vistas
{
    public partial class VistaVehiculos
    {
        
        public int Id { get; set; }
        public string? Patente { get; set; }
        public int? IdTipo { get; set; }
        public string? Tipo { get; set; }
        public int IdModelo { get; set; }
        public string? Modelo { get; set; }
        public int IdMarca { get; set; }
        public string? Marca { get; set; }
        public string? Combustible { get; set; }
        public int? Stock { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
