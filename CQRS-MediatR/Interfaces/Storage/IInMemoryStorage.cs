using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.MediatR.Interfaces.Storage
{
    public interface IInMemoryStorage
    {
        Task Save<T>(T data, bool upsert);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "<Pending>")]
        Task<T> Get<T>(Guid id);

        Task<IList<T>> GetAll<T>()
            where T : class;
    }
}
