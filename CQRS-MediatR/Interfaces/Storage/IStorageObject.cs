using System;

namespace CQRS.MediatR.Interfaces.Storage
{
    public interface IStorageObject
    {
        Guid Id { get; set; }
    }
}
