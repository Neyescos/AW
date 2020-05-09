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
            CreateMap<UserDTO, UserModel>()
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
            CreateMap<ProductDTO, ProductModel>()
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
                dest => dest.Product,
                opts => opts.MapFrom(src => src.Product));
            CreateMap<ImageDTO, ImageModel>()
                .ForMember(
                dest => dest.Product,
                opts => opts.MapFrom(src => src.Product));

            CreateMap<WarehouseModel, WarehouseDTO>()
                .ForMember(
                dest => dest.Product,
                opts => opts.MapFrom(src => src.Product));
            CreateMap<WarehouseDTO,WarehouseModel>()
                .ForMember(
                dest => dest.Product,
                opts => opts.MapFrom(src => src.Product));

        }
    }
}
