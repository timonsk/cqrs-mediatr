using System;

namespace CQRS.MediatR.Models.ResponseModels.Queries
{
    public class GetProductByIdResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }
    }
}
