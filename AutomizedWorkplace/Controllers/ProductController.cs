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
        public ProductController(IProductService serv,IMapper mapper)
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

        [Authorize]
        [HttpGet]
        public async Task<ProductModel> Get(int id)
        {
            return mapper.Map<ProductModel>(await service.GetProduct(id));
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return Ok();
        }
    }
}
