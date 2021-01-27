using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers.MappingProfiles
{
    public class ProductsMappingProfiles: Profile
    {
        public ProductsMappingProfiles()
        {
            CreateMap<Product, ProductToReturn>()
                .ForMember(dest => dest.ProductBrand, src => src.MapFrom(opt => opt.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, src => src.MapFrom(opt => opt.ProductType.Name))
                .ForMember(des => des.PictureUrl, src => src.MapFrom<ProductUrlResolver>());
            // for Testing
            //.ForMember(dest=>dest.PictureUrl,src=>src.MapFrom(opt=>opt.PictureUrl.ReturnProductPictureUrl()));
        }
    }
}
