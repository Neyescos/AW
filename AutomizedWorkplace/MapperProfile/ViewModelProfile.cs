using AutomizedWorkplace.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;

namespace AutomizedWorkplace.MapperProfile
{
    public class ViewModelProfile:Profile
    {
        public ViewModelProfile()
        {
            CreateMap<UserModel, UserDTO>()
                .ForMember(
                dest => dest.Products,
                opts => opts.MapFrom(src => src.Products));
            CreateMap<ProductModel, ProductDTO>()
               .ForMember(
                dest => dest.Picture,
                opts => opts.MapFrom(src => src.Picture))
               .ForMember(
                dest => dest.WarehouseId,
                opts => opts.MapFrom(src => src.WarehouseId))
               .ForMember(
                dest => dest.UserId,
                opts => opts.MapFrom(src => src.UserId));
            CreateMap<ImageModel, ImageDTO>()
                .ForMember(
                dest => dest.ProductId,
                opts => opts.MapFrom(src => src.ProductId));
               
        }
    }
}
