using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteRepostory<Product>().AddAsync(product);
            var result = await unitOfWork.SaveAsync();
            if(result > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepostory<CategoryProduct>().AddAsync(new()
                    {
                        CategoryId = categoryId,
                        ProductId = product.Id
                    });
                }

                result = await unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
