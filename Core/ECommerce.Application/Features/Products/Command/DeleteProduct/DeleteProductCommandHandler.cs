using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitofwork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitofwork.GetReadRepostory<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            product.IsDeleted = true;
            await unitofwork.GetWriteRepostory<Product>().SoftDeleteAsync(product);
            await unitofwork.SaveAsync();

            return Unit.Value;
        }
    }
}
