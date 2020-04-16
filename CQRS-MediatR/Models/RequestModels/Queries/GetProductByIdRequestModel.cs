using System;

namespace CQRS.MediatR.Models.RequestModels.Queries
{
    public class GetProductByIdRequestModel
    {
        public Guid ProductId { get; set; }
    }
}
