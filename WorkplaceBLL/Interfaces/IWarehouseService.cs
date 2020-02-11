using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IWarehouseService
    {
        void MakeWarehouse(WarehouseDTO warehouseDTO);
        WarehouseDTO GetWarehouse(int? id);
        IEnumerable<WarehouseDTO> GetWarehouses();
        void Dispose();
    }
}
