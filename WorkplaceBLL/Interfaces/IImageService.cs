using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IImageService
    {
        void MakeImage(ImageDTO imageDTO);
        ImageDTO GetImage(int? id);
        IEnumerable<ImageDTO> GetImages();
        void Dispose();
    }
}
