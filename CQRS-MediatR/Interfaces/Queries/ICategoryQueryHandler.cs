using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.MediatR.Models.RequestModels.Queries;
using CQRS.MediatR.Models.ResponseModels.Queries;

namespace CQRS.MediatR.Interfaces.Queries
{
    public interface ICategoryQueryHandler
    {
        Task<List<GetCategoryByNameResponseModel>> GetCategoryByName(GetCategoryByNameRequestModel categoryByNameRequestModel);
    }
}
