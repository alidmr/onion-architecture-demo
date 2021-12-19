using AutoMapper;
using ProductApp.Application.Dtos;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();

            CreateMap<CreateProductCommand, Product>().ReverseMap();

            CreateMap<GetProductByIdViewModel, Product>().ReverseMap();
        }
    }
}
