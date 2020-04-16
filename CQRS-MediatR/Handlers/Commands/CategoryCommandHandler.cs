using System;
using System.Threading.Tasks;
using CQRS.MediatR.Interfaces.Commands;
using CQRS.MediatR.Interfaces.Storage;
using CQRS.MediatR.Models.RequestModels.Commands;
using CQRS.MediatR.Models.ResponseModels.Commands;
using CQRS.MediatR.Models.Stoarage;

namespace CQRS.MediatR.Handlers.Commands
{
    public class CategoryCommandHandler : ICategoryCommandHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public CategoryCommandHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage != null ? inMemoryStorage : throw new ArgumentNullException(nameof(inMemoryStorage));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task<CreateCategoryResponseModel> CreateCategory(CreateCategoryRequestModel createCategoryRequestModel)
        {
            if (createCategoryRequestModel == null)
            {
                throw new ArgumentNullException(nameof(createCategoryRequestModel));
            }

            var createCategoryResponseModel = new CreateCategoryResponseModel();

            try
            {
                await _inMemoryStorage.Save(
                    new Category
                    {
                        Id = createCategoryRequestModel.Id,
                        Description = createCategoryRequestModel.Description,
                        Name = createCategoryRequestModel.Name,
                        UserId = createCategoryRequestModel.UserId,
                    }, true)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                createCategoryResponseModel.ErrorMessage = ex.Message;
            }

            return createCategoryResponseModel;
        }
    }
}
