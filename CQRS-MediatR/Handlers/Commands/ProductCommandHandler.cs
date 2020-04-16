using System;
using System.Threading.Tasks;
using CQRS.MediatR.Interfaces.Commands;
using CQRS.MediatR.Interfaces.Storage;
using CQRS.MediatR.Models.RequestModels.Commands;
using CQRS.MediatR.Models.ResponseModels.Commands;
using CQRS.MediatR.Models.Stoarage;

namespace CQRS.MediatR.Handlers.Commands
{
    public class ProductCommandHandler : IProductCommandHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public ProductCommandHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage != null ? inMemoryStorage : throw new ArgumentNullException(nameof(inMemoryStorage));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task<CreateProductResponseModel> CreateProduct(CreateProductRequestModel productRequestModel)
        {
            if (productRequestModel == null)
            {
                throw new ArgumentNullException(nameof(productRequestModel));
            }

            var createProductResponseModel = new CreateProductResponseModel();

            try
            {
                await _inMemoryStorage.Save(
                    new Product
                {
                    Id = productRequestModel.Id,
                    CreateDate = DateTime.Now,
                    Name = productRequestModel.Name,
                    CategoryId = productRequestModel.CategoryId,
                    Description = productRequestModel.Description,
                    UserId = productRequestModel.UserId,
                }, true)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                createProductResponseModel.ErrorMessage = ex.Message;
            }

            return createProductResponseModel;
        }
    }
}
