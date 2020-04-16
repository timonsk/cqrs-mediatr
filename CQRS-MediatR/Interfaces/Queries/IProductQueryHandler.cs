using System.Threading.Tasks;
using CQRS.MediatR.Models.RequestModels.Queries;
using CQRS.MediatR.Models.ResponseModels.Queries;

namespace CQRS.MediatR.Interfaces.Queries
{
    public interface IProductQueryHandler
    {
         Task<GetProductByIdResponseModel> GetProductById(GetProductByIdRequestModel productModel);
    }
}
