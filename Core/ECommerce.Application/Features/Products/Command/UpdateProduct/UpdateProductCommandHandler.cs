using ECommerce.Application.AutoMapper;
using ECommerce.Application.Features.Products.Command.CreateProduct;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepostory<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories = await unitOfWork.GetReadRepostory<CategoryProduct>()
                .GetAllAsync(x => x.ProductId == product.Id);

            await unitOfWork.GetWriteRepostory<CategoryProduct>()
                .HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepostory<CategoryProduct>()
                    .AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
            }

            await unitOfWork.GetWriteRepostory<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
