using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.InMemory
{
    //: - implementacja interfejsu
    public class EntityAsyncService<T> : IEntityAsyncService<T> where T : Entity //gdzie T dziedziczy po Entity
    {
        protected ICollection<T> _entities { get; set; }

        public EntityAsyncService()
        {
            _entities = new List<T>();
        }

        public virtual async Task<int> CreateAsync(T entity)
        {

            await Task.Delay(1000);

            int id = 0;
            if(_entities.Any())
                id = _entities.Max(x => x.Id);
            id += 1;
            entity.Id = id;
            _entities.Add(entity);

            return id;
        }

        public virtual Task<bool> DeleteAsync(int id)
        {
            var entity = _entities.Where(x => !x.IsDeleted).SingleOrDefault(x => x.Id == id);
            if(!entity?.IsDeleted ?? false)
            {
                entity.IsDeleted = true;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }


        public Task<T?> ReadAsync(int id)
        {
            var result = (T?) _entities
                .Where(x => !x.IsDeleted)
                .Where(x => x.Id == id)
                .SingleOrDefault()?.Clone() ?? default;

            return Task.FromResult(result);
        }

        public Task<IEnumerable<T>> ReadAsync()
        {
            var result = _entities.Where(x => !x.IsDeleted)
                            .Select(x => x.Clone())
                            .Cast<T>()
                            .ToList()
                            .AsEnumerable();


            return Task.FromResult(result);
        }

        public virtual async Task UpdateAsync(int id, T entity)
        {
            if (await DeleteAsync(id))
            {
                entity.Id = id;
                _entities.Add(entity);
            }
        }
    }
}
