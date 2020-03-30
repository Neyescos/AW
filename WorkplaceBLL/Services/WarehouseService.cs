using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;
using WorkplaceBLL.Interfaces;
using WorkplaceBLL.MapProfiles;
using WorkplaceDAL;
using WorkplaceDAL.Interfaces;
using WorkplaceDAL.Models;

namespace WorkplaceBLL.Services
{
    class WarehouseService : IWarehouseService
    {
        readonly IUnitOfWork unit;

        public WarehouseService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MyProfile());
        });
        public async Task<WarehouseDTO> GetWarehouse(int? id)
        {
            var mapper = new Mapper(config);
            var warehouse = await unit.Warehouses.Find(x=>x.Id==id);
            return mapper.Map<Warehouse, WarehouseDTO>(warehouse);
        }

        public async Task<IEnumerable<WarehouseDTO>> GetWarehouses()
        {
            var mapper =new Mapper(config);
            var warehouses =await unit.Warehouses.GetAll();
            return mapper.Map<IEnumerable<WarehouseDTO>>(warehouses);
        }

        public async Task MakeWarehouse(WarehouseDTO warehouseDTO)
        {
            var mapper = new Mapper(config);
            await unit.Warehouses.Create(mapper.Map<WarehouseDTO, Warehouse>(warehouseDTO));
        }

        public async Task Delete(int id)
        {
            await unit.Warehouses.Delete(id);
        }
    }
}
