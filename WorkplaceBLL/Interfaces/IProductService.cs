using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IProductService
    {
        Task MakeProduct(ProductDTO productDTO);
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}
