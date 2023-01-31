using AutoMapper;
using DevShop.Application.DTOs.Products;
using DevShop.Application.DTOs.User;
using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUser, AppUser>().ReverseMap();
            CreateMap<UserLogin, AppUser>().ReverseMap();
            CreateMap<CatagoryDTO, Catagory>().ReverseMap();
            CreateMap<CatagoryDTO, SubCatagory>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
