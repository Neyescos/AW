using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using WorkplaceBLL.DTO;
using WorkplaceBLL.Interfaces;
using WorkplaceBLL.MapProfiles;
using WorkplaceDAL.Interfaces;
using WorkplaceDAL.Models;

namespace WorkplaceBLL.Services
{
    public class ImageService : IImageService
    {
        readonly IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MyProfile());
        });
        public ImageService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public async Task DeleteImage(int id, string _appEnvironment)
        {
            Image image = await unit.Images.Get(id);
            var imgName = image.Url.Split('/')[4];
            await unit.Images.Delete(id);
            File.Delete(_appEnvironment + "\\Images\\" + imgName);
            unit.Save();
        }

        public async Task<IEnumerable<ImageDTO>> GetImage(int id)
        {
            var mapper = new Mapper(config);
            var images = await unit.Images.Find(x=>x.Id == id);
            return mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public async Task UploadImage(string _appEnvironment, IFormFile image)
        {
            var mapper = new Mapper(config);
            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnvironment + path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            Image uploadedImage = new Image { Url = "https://localhost:44340" + path};
            await unit.Images.Create(uploadedImage);
        }

    }
}
