using BE_WebAPI_Vehiculos.Common.Dtos;
using BE_WebAPI_Vehiculos.Common.Models;
using BE_WebAPI_Vehiculos.Repository.Interfaces;
using BE_WebAPI_Vehiculos.Services.Interfaces;

namespace BE_WebAPI_Vehiculos.Services
{
    public class VehiculoServices : IVehiculoServices
    {
        private IVehiculoRepository _iVehiculoRepository;
        private List<Vehiculo> _vehiculos;
        private Vehiculo _vehiculo;

        public VehiculoServices(IVehiculoRepository iVehiculoRepository)
        {
            this._iVehiculoRepository = iVehiculoRepository;
        }

        public async Task<VehiculosDto> ObtenerVehiculos()
        {
            _vehiculos = await _iVehiculoRepository.ObtenerVehiculos().ConfigureAwait(false);

            return await Task.Run(() => new VehiculosDto()
            {
                Vehiculos = _vehiculos
            });
        }

        public async Task<VehiculosDto> ObtenerVehiculosVista()
        {
            _vehiculos = await _iVehiculoRepository.ObtenerVehiculosVista().ConfigureAwait(false);

            return await Task.Run(() => new VehiculosDto()
            {
                Vehiculos = _vehiculos
            });
        }

        public async Task<bool> CrearVehiculo(VehiculoDto vehiculoDto)
        {
            Common.Models.Vehiculo vehiculo = new Vehiculo()
            {
                Id = vehiculoDto.Id,
                Patente = vehiculoDto.Patente,
                Combustible = vehiculoDto.Combustible,
                Stock = vehiculoDto.Stock,
                ModeloVehiculo = vehiculoDto.ModeloVehiculo,
                Tipo = vehiculoDto.Tipo,
                Fecha = vehiculoDto.Fecha
            };

            return await _iVehiculoRepository.CrearVehiculo(vehiculo);
        }

        public async Task<bool> BorrarVehiculo(int id)
        {
            return await Task.Run(() => _iVehiculoRepository.BorrarVehiculo(id));
        }

        public async Task<bool> ModificarVehiculo(VehiculoDto vehiculoDto)
        {
            Common.Models.Vehiculo vehiculo = new Vehiculo()
            {
                Id = vehiculoDto.Id,
                Combustible = vehiculoDto.Combustible,
                Stock = vehiculoDto.Stock,
                Fecha = vehiculoDto.Fecha,
                Patente = vehiculoDto.Patente,
                Tipo = vehiculoDto.Tipo,
                ModeloVehiculo = vehiculoDto.ModeloVehiculo
            };

            return await Task.Run(() => _iVehiculoRepository.ModificarVehiculo(vehiculo));
        }

        public async Task<Common.Dtos.VehiculoDto> ObtenerVehiculoPorId(int id)
        {
            _vehiculo = await _iVehiculoRepository.ObtenerVehiculoPorId(id);

            Common.Dtos.VehiculoDto vehiculoDto = new VehiculoDto()
            {
                Id = _vehiculo.Id,
                Combustible = _vehiculo.Combustible,
                Patente = _vehiculo.Patente,
                Stock = _vehiculo.Stock,
                Fecha = _vehiculo.Fecha,
                ModeloVehiculo = _vehiculo.ModeloVehiculo,
                Tipo = _vehiculo.Tipo
            };

            return await Task.Run(() => vehiculoDto);
        }

    }
}
