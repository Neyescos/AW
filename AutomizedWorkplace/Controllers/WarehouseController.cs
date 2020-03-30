﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutomizedWorkplace.MapperProfile;
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
    public class WarehouseController : ControllerBase
    {
       
        IWarehouseService service;
        IMapper mapper;
        public WarehouseController(IMapper mapper, IWarehouseService serv)
        {
            service = serv;
            this.mapper = mapper;
        }
        // GET: api/Warehouse
        [Authorize]
        [HttpGet]
        public async  Task<IEnumerable<WarehouseModel>> Get()
        {
            return mapper.Map<IEnumerable<WarehouseModel>>(await service.GetWarehouses());
        }

        // GET: api/Warehouse/5
        [Authorize]
        [HttpGet]
        public async Task<WarehouseModel> Get(int id)
        {
            return mapper.Map<WarehouseModel>(await service.GetWarehouse(id));
        }

        // POST: api/Warehouse
        [Authorize]
        [HttpPost]
        public async Task<IEnumerable<WarehouseModel>> Post(WarehouseModel query)
        {
           
            return mapper.Map<WarehouseModel>(await service.MakeWarehouse(new WorkplaceBLL.DTO.WarehouseDTO { Date = query.Date, Id = query.Id, Product =mapper.Map<ProductModel>( query.Product) })) ;
        }

        // PUT: api/Warehouse/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return Ok();
        }
    }
}