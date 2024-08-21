using MediatR;

namespace ECommerce.Application.Features.Products.Queires.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
    {
        
    }
}
