using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutomizedWorkplace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkplaceBLL.Interfaces;

namespace AutomizedWorkplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IImageService service;
        IWebHostEnvironment hostingEnviroment;
        IMapper mapper;
        public ImageController(IMapper mapper,IImageService serv, IWebHostEnvironment hostingEnviroment)
        {
            service = serv;
            this.hostingEnviroment = hostingEnviroment;
            this.mapper = mapper;
        }
        // GET: api/Image
        
        // GET: api/Image/5
        [Authorize]
        [HttpGet]
        public async Task<ImageModel> GetImage(int id)
        {
            return mapper.Map<ImageModel>( await service.GetImage(Convert.ToInt32(id)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile image)
        {
            await service.UploadImage(hostingEnviroment.ContentRootPath,image);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteImage(id,hostingEnviroment.ContentRootPath);
            return Ok();
        }
    }
}
