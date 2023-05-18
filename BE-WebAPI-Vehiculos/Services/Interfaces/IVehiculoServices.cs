using BE_WebAPI_Vehiculos.Common.Dtos;

namespace BE_WebAPI_Vehiculos.Services.Interfaces
{
    public interface IVehiculoServices
    {
        public Task<VehiculosDto> ObtenerVehiculos();
        public Task<VehiculosDto> ObtenerVehiculosVista();
        public Task<bool> CrearVehiculo(VehiculoDto vehiculoDto);
        public Task<bool> BorrarVehiculo(int id);
        public Task<bool> ModificarVehiculo(VehiculoDto vehiculoDto);
        public Task<Common.Dtos.VehiculoDto> ObtenerVehiculoPorId(int id);
    }
}
