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
    public class EntityService<T> : IEntityService<T> where T : Entity //gdzie T dziedziczy po Entity
    {
        protected ICollection<T> _entities { get; set; }

        public EntityService()
        {
            _entities = new List<T>();
        }

        public virtual int Create(T entity)
        {
            int id = 0;
            /*foreach (var item in _entities)
            {
                if (item.Id > id)
                    id = item.Id;
            }*/

            //var id = _entities.Select(x => x.Id).Max();
            if(_entities.Any())
                id = _entities.Max(x => x.Id);
            id += 1;
            entity.Id = id;
            _entities.Add(entity);

            return id;
        }

        public virtual bool Delete(int id)
        {
            var entity = _entities.Where(x => !x.IsDeleted).SingleOrDefault(x => x.Id == id);
            //if (entity != null && !entity.IsDeleted)
            if(!entity?.IsDeleted ?? false)
            {
                //return _entities.Remove(entity);
                entity.IsDeleted = true;
                return true;
            }
            return false;
        }


        public T? Read(int id)
        {
            /*foreach (var entity in _entities)
            {
                if(entity.Id == id)
                    return entity;
            }
            return null;*/

            return (T?) _entities
                .Where(x => !x.IsDeleted)
                .Where(x => x.Id == id)
                .SingleOrDefault()?.Clone() ?? default;
        }

        public IEnumerable<T> Read()
        {
            //return new List<Person>(_entities);
            return _entities.Where(x => !x.IsDeleted)
                            .Select(x => x.Clone())
                            .Cast<T>()
                            .ToList();
        }

        public virtual void Update(int id, T entity)
        {
            if (Delete(id))
            {
                entity.Id = id;
                _entities.Add(entity);
            }
        }
    }
}
