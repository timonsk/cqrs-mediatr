using System;
using CQRS.MediatR.Interfaces.Storage;

namespace CQRS.MediatR.Models.Stoarage
{
    public class Category : IStorageObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
