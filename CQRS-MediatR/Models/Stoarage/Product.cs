using System;
using CQRS.MediatR.Interfaces.Storage;

namespace CQRS.MediatR.Models.Stoarage
{
    public class Product : IStorageObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
