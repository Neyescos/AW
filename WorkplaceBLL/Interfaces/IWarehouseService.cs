using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IWarehouseService
    {
        Task MakeWarehouse(WarehouseDTO warehouseDTO);
        Task<WarehouseDTO> GetWarehouse(int? id);
        Task<IEnumerable<WarehouseDTO>> GetWarehouses();
       
    }
}
