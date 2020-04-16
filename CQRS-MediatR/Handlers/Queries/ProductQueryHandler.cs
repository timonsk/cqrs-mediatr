using System;
using System.Threading.Tasks;
using CQRS.MediatR.Interfaces.Queries;
using CQRS.MediatR.Interfaces.Storage;
using CQRS.MediatR.Models.RequestModels.Queries;
using CQRS.MediatR.Models.ResponseModels.Queries;
using CQRS.MediatR.Models.Stoarage;

namespace CQRS.MediatR.Handlers.Queries
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public ProductQueryHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage != null ? inMemoryStorage : throw new ArgumentNullException(nameof(inMemoryStorage));
        }

        public async Task<GetProductByIdResponseModel> GetProductById(GetProductByIdRequestModel productModel)
        {
            if (productModel == null)
            {
                throw new ArgumentNullException(nameof(productModel));
            }

            var product = await _inMemoryStorage.Get<Product>(productModel.ProductId).ConfigureAwait(false);

            return new GetProductByIdResponseModel
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name,
                UserId = product.UserId,
            };
        }
    }
}
