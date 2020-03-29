using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IProductService
    {
        Task MakeProduct(ProductDTO productDTO);
        Task<ProductDTO> GetProduct(int? id);
        Task<IEnumerable<ProductDTO>> GetProducts();
        
    }
}
