using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var productEntity = _mapper.Map<Product>(request);

                var product = await _productRepository.AddAsync(productEntity);

                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
