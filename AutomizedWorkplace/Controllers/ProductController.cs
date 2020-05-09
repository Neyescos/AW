using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutomizedWorkplace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkplaceBLL.DTO;
using WorkplaceBLL.Interfaces;

namespace AutomizedWorkplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMapper mapper;
        IProductService service;
        public ProductController(IProductService serv, IMapper mapper)
        {
            this.mapper = mapper;
            service = serv;
        }
        // GET: api/Product
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<ProductModel>> Get()
        {
            return mapper.Map<IEnumerable<ProductModel>>(await service.GetProducts());
        }

        // POST: api/Product
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(ProductModel query)
        {
            await service.MakeProduct(mapper.Map<ProductDTO>(query));
            return Ok();
        }

        // PUT: api/Product/5
        [Authorize]
        [HttpPut]
        public IActionResult Put(ProductModel product)
        {
            service.Update(mapper.Map<ProductDTO>(product));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            await service.Delete(id);
            return Ok();
        }
    }
}
