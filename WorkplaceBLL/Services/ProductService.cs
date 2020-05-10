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

namespace WorkplaceBLL.Services
{
    public class ProductService : IProductService
    {
        readonly IUnitOfWork unit;

        public ProductService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MyProfile());
        });
       

        public async Task<ProductDTO> GetProduct(int? id)
        {
            var mapper = new Mapper(config);
            var product = await unit.Products.Find(temp => temp.Id == temp.Id);
            return mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var mapper = new Mapper(config);
            var products = await unit.Products.GetAll();
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async  Task MakeProduct(ProductDTO product)
        {
            var mapper = new Mapper(config);
            unit.Products.Create(mapper.Map<ProductDTO, Product>(product));
            unit.Save();
        }

        public async Task Delete(int id)
        {
            await unit.Products.Delete(id);
            unit.Save();
            
        }

        public  void Update(ProductDTO product)
        {
            var mapper = new Mapper(config);
            unit.Products.Update(mapper.Map<Product>(product));
            unit.Save();

        }
    }
}
