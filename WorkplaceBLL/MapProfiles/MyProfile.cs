using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceBLL.DTO;
using WorkplaceDAL;
using WorkplaceDAL.Models;

namespace WorkplaceBLL.MapProfiles
{
    public class MyProfile:Profile
    {
        public MyProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(
                dest => dest.Products,
                opts => opts.MapFrom(src => src.Products));
            CreateMap<User, UserDTO>()
                .ForMember(
                dest => dest.Products,
                opts => opts.MapFrom(src => src.Products));

            CreateMap<ProductDTO, Product>()
                .ForMember(
                dest => dest.Picture,
                opts => opts.MapFrom(src => src.Picture))
                .ForMember(
                dest => dest.WarehouseId,
                opts => opts.MapFrom(src => src.WarehouseId))
                .ForMember(
                dest => dest.UserId,
                opts => opts.MapFrom(src => src.UserId));
            CreateMap<Product, ProductDTO>()
                .ForMember(
                dest => dest.Picture,
                opts => opts.MapFrom(src => src.Picture))
                .ForMember(
                dest=>dest.WarehouseId,
                opts=>opts.MapFrom(src=>src.WarehouseId))
                .ForMember(
                dest=>dest.UserId,
                opts=>opts.MapFrom(src=>src.UserId));

            CreateMap<WarehouseDTO, Warehouse>()
                .ForMember(
                dest => dest.Product,
                opts => opts.MapFrom(src => src.Product));
            CreateMap<Warehouse, WarehouseDTO>()
                .ForMember(
                dest => dest.Product,
                opts => opts.MapFrom(src => src.Product));

            CreateMap<ImageDTO, Image>()
                .ForMember(
                dest => dest.Product,
                opts => opts.MapFrom(src => src.ProductId));
            CreateMap<Image, ImageDTO>()
                .ForMember(
                dest => dest.Product,
                opts => opts.MapFrom(src => src.Product));
           
        }
    }
}
