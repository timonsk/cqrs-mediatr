using System;

namespace CQRS.MediatR.Models.RequestModels.Commands
{
    public class CreateProductRequestModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }
    }
}
