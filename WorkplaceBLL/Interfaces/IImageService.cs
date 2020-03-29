using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IImageService
    {
        Task<IEnumerable<ImageDTO>> GetImages(UserDTO user);
        Task UploadImage(string _appEnvironment, IFormFile image, string user);
        Task DeleteImage(int id, string _appEnvironment);

    }
}
