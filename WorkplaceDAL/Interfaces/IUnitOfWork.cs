using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceDAL.Models;

namespace WorkplaceDAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<User>Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Image> Images { get; }
        IRepository<Warehouse> Warehouses { get; }
        
        void Save();
        
    }
}
