namespace BE_WebAPI_Vehiculos.Repository.Interfaces
{
    public interface IVehiculoRepository
    {
        public Task<List<Common.Models.Vehiculo>> ObtenerVehiculos();
        public Task<List<Common.Models.Vehiculo>> ObtenerVehiculosVista();
        public Task<bool> CrearVehiculo(Common.Models.Vehiculo vehiculo);
        public Task<bool> BorrarVehiculo(int id);
        public Task<bool> ModificarVehiculo(Common.Models.Vehiculo vehiculo);
        public Task<Common.Models.Vehiculo> ObtenerVehiculoPorId(int id);
    }
}
