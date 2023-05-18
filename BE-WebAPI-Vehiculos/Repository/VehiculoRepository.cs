using BE_WebAPI_Vehiculos.Common.Models;
using BE_WebAPI_Vehiculos.Repository.Entities;
using BE_WebAPI_Vehiculos.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE_WebAPI_Vehiculos.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly BdvehiculosContext _context = new BdvehiculosContext();
        private List<Common.Models.Vehiculo> _vehiculos = new List<Common.Models.Vehiculo>();
        private Common.Models.Vehiculo _vehiculo;

        public async Task<List<Common.Models.Vehiculo>> ObtenerVehiculos()
        {
            _vehiculos.Clear();

            var listaVehiculos = from vehiculosBD in _context.Vehiculos
                                 join tipoBD in _context.TipoVehiculos on vehiculosBD.IdTipo equals tipoBD.Id
                                 join modeloBD in _context.Modelos on vehiculosBD.IdModelo equals modeloBD.Id
                                 join marcaBD in _context.Marcas on modeloBD.IdMarca equals marcaBD.Id

                                 select new
                                 {
                                     Ident = vehiculosBD.Id,
                                     Patent = vehiculosBD.Patente,
                                     Combust = vehiculosBD.Combustible,
                                     Sto = vehiculosBD.Stock,
                                     TipoId = tipoBD.Id,
                                     TipoNombre = tipoBD.Nombre,
                                     ModeloId = modeloBD.Id,
                                     ModeloNombre = modeloBD.Nombre,
                                     ModeloMarca = modeloBD.IdMarca,
                                     MarcaNombre = marcaBD.Nombre,
                                     Fecha = vehiculosBD.Fecha

                                 };



            foreach (var item in listaVehiculos)
            {
                _vehiculos.Add(new Common.Models.Vehiculo
                {
                    Combustible = item.Combust,
                    Id = item.Ident,
                    Patente = item.Patent,
                    Stock = item.Sto,
                    Fecha = item.Fecha,
                    Tipo = new Common.Models.TipoVehiculo { Id = item.TipoId, Nombre = item.TipoNombre },                    
                    ModeloVehiculo = new Common.Models.Modelo { Id = item.ModeloId, Nombre = item.ModeloNombre, MarcaVehiculo = new Common.Models.Marca { Id = item.ModeloMarca, Nombre = item.MarcaNombre } }
                });
            }

            return await Task.Run(() => _vehiculos);
        }

        /// <summary>
        /// Obtener Vehículos, utilizando una Vista en SQL.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Common.Models.Vehiculo>> ObtenerVehiculosVista()
        {
            _vehiculos.Clear();

            var listaVehiculos = from vehiculosBD in _context.VistaVehiculosLista
                                 select vehiculosBD;

            foreach (var item in listaVehiculos)
            {
                _vehiculos.Add(new Common.Models.Vehiculo()
                {
                    Id = item.Id,                    
                    Patente = item.Patente,
                    Tipo = new Common.Models.TipoVehiculo {Id = item.IdTipo, Nombre = item.Tipo },
                    ModeloVehiculo = new Common.Models.Modelo { Id = item.IdModelo, Nombre = item.Modelo, MarcaVehiculo = new Common.Models.Marca {Id = item.IdMarca, Nombre = item.Marca } },
                    Fecha = item.Fecha,
                    Combustible = item.Combustible,
                    Stock = item.Stock,                    
                });
            }

            return await Task.Run(() => _vehiculos);
        }

        public async Task<bool> CrearVehiculo(Common.Models.Vehiculo vehiculo)
        {
            Entities.Vehiculo vehiculoBD = new Entities.Vehiculo()
            {
                Id = vehiculo.Id,
                Combustible = vehiculo.Combustible,
                Fecha = vehiculo.Fecha,
                IdModelo = vehiculo.ModeloVehiculo.Id,
                IdTipo = vehiculo.Tipo.Id,
                Patente = vehiculo.Patente,
                Stock = vehiculo.Stock
            };

            _context.Vehiculos.Add(vehiculoBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> BorrarVehiculo(int id)
        {            
            var lista = from vehiculoID in _context.Vehiculos
                        where vehiculoID.Id == id
                        select vehiculoID;


            foreach (var item in lista)
            {                
                _context.Vehiculos.Remove(item);
            }

            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> ModificarVehiculo(Common.Models.Vehiculo vehiculo)
        {
            Repository.Entities.Vehiculo vehiculoBD = new Entities.Vehiculo()
            {
                Id = vehiculo.Id,
                Combustible = vehiculo.Combustible,
                Patente = vehiculo.Patente,
                Fecha = vehiculo.Fecha,
                IdModelo = vehiculo.ModeloVehiculo.Id,
                IdTipo = vehiculo.Tipo.Id,
                Stock = vehiculo.Stock
            };

            _context.Vehiculos.Update(vehiculoBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<Common.Models.Vehiculo> ObtenerVehiculoPorId(int id)
        {
            var lista = from vehiculoBD in _context.Vehiculos
                        where vehiculoBD.Id == id
                        select vehiculoBD;

            foreach (var item in lista)
            {
                _vehiculo = new Common.Models.Vehiculo()
                {
                    Id = item.Id,
                    Combustible = item.Combustible,
                    Stock = item.Stock,
                    Patente = item.Patente,
                    Fecha = item.Fecha,
                    ModeloVehiculo = new Common.Models.Modelo { Id = item.IdModelo },
                    Tipo = new Common.Models.TipoVehiculo { Id= item.IdTipo }
                };
            }

            return await Task.Run(() => _vehiculo);
        }

        
    }
}
