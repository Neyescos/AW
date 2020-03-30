using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    public interface IProductService
    {
        Task MakeProduct(ProductDTO productDTO);
        Task<ProductDTO> GetProduct(int? id);
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task Delete(int id);
        Task<ProductDTO> Update(ProductDTO product);
    }
}
