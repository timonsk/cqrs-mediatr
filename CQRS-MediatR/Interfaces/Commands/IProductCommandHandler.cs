using System.Threading.Tasks;
using CQRS.MediatR.Models.RequestModels.Commands;
using CQRS.MediatR.Models.ResponseModels.Commands;

namespace CQRS.MediatR.Interfaces.Commands
{
    public interface IProductCommandHandler
    {
         Task<CreateProductResponseModel> CreateProduct(CreateProductRequestModel productRequestModel);
    }
}
