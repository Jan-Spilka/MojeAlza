using Application.DataTransferObjects;
using AutoMapper;
using Core.Models;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product, ProductDTO>();
            this.CreateMap<ProductDTO, Product>();
        }
    }
}
