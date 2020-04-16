using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CQRS.MediatR.Interfaces.Commands;
using CQRS.MediatR.Interfaces.Queries;
using CQRS.MediatR.Models.RequestModels.Commands;
using CQRS.MediatR.Models.RequestModels.Queries;
using CQRS.MediatR.Models.ResponseModels.Commands;
using CQRS.MediatR.Models.ResponseModels.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRS.MediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ICategoryCommandHandler _categoryCommandHandler;
        private readonly ICategoryQueryHandler _categoryQueryHandler;

        public CategoryController(
            ILogger<ProductController> logger,
            ICategoryCommandHandler categoryCommandHandler,
            ICategoryQueryHandler categoryQueryHandler)
        {
            _logger = logger;
            _categoryCommandHandler = categoryCommandHandler;
            _categoryQueryHandler = categoryQueryHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<GetCategoryByNameResponseModel>), (int)HttpStatusCode.OK)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task<IActionResult> Get([FromQuery] string categoryName)
        {
            _logger.LogDebug($"Got request for getting category by name: {categoryName}");
            try
            {
                return Ok(await _categoryQueryHandler.GetCategoryByName(new GetCategoryByNameRequestModel { Name = categoryName })
                    .ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCategoryResponseModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestModel categoryRequestModel)
        {
            _logger.LogDebug($"Got request for creating category with name: {categoryRequestModel?.Name} and user id: {categoryRequestModel?.UserId}");
            return CreatedAtAction("Create", new { categoryName = categoryRequestModel.Name }, await _categoryCommandHandler.CreateCategory(categoryRequestModel).ConfigureAwait(false));
        }
    }
}
