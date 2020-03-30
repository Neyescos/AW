using WorkplaceBLL.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace WorkplaceBLL.Interfaces
{
    public interface IImageService
    {
        Task<IEnumerable<ImageDTO>> GetImage(int id);
        Task UploadImage(string _appEnvironment, IFormFile image);
        Task DeleteImage(int id, string _appEnvironment);

    }
}
