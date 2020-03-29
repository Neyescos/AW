using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceDAL.EF;
using WorkplaceDAL.Interfaces;
using WorkplaceDAL.Models;
using WorkplaceDAL.Repositories;


namespace WorkplaceDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkPlaceContext db;
        private IRepository<User> userRepository;
        private IRepository<Product> productRepository;
        private IRepository<Image> imageRepository;
        private IRepository<Warehouse> warehouseRepository;
        
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(db);
                }
                return userRepository;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new Repository<Product>(db);
                }
                return productRepository;
            }
        }
        public IRepository<Image> Images
        {
            get
            {
                if (imageRepository == null)
                {
                    imageRepository = new Repository<Image>(db);
                }
                return imageRepository;
            }
        }
      
        public IRepository<Warehouse> Warehouses
        {
            get
            {
                if (warehouseRepository == null)
                {
                    warehouseRepository = new Repository<Warehouse>(db);
                }
                return warehouseRepository;
            }
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposed)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
