using ECommerce.Application.AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queires.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        IUnitOfWork unitofWork;
        IMapper mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
           this.unitofWork = unitofWork;
           this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            throw new Exception("Mustafa Yener");

            var products = await unitofWork.GetReadRepostory<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));


            mapper.Map<BrandDto, Brand>(new Brand());

            //var response = products.Select(s => new GetAllProductsQueryResponse
            //{
            //    Title = s.Title,
            //    Description = s.Description,
            //    Price = s.Price,
            //    Discount = s.Discount
            //}).ToList();

          

            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            return map;
        }
    }
}
