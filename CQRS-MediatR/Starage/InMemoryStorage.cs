using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.MediatR.Interfaces.Storage;

namespace CQRS.MediatR.Storage
{
    public class InMemoryStorage : IInMemoryStorage
    {
        private Dictionary<Guid, object> _storage = new Dictionary<Guid, object>();

        public Task<T> Get<T>(Guid id)
        {
            if (!_storage.ContainsKey(id))
            {
                return Task.FromResult((T)Activator.CreateInstance(typeof(T)));
            }

            return Task.FromResult((T)_storage[id]);
        }

        public Task<IList<T>> GetAll<T>()
            where T : class
        {
            return Task.FromResult(_storage.Keys.Any()
                ? _storage.Values.Where(v => v as T != null).Select(v => v as T).ToList()
                : (IList<T>)Activator.CreateInstance(typeof(IList<T>)));
        }

        public Task Save<T>(T data, bool upsert)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var stObject = data as IStorageObject;
            if (stObject == null)
            {
                throw new InvalidOperationException($"Object is not type of {typeof(IStorageObject)}");
            }

            if (_storage.ContainsKey(stObject.Id))
            {
                if (!upsert)
                {
                    throw new ArgumentException($"Duplicate primary key: {stObject.Id}");
                }

                _storage[stObject.Id] = data;
            }

            _storage.Add(stObject.Id, data);

            return Task.CompletedTask;
        }
    }
}
