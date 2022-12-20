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
        protected readonly ICollection<T> _entities;

        public EntityService()
        {
            _entities = new List<T>();
        }

        public int Create(T entity)
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

        public bool Delete(int id)
        {
            var entity = Read(id);
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

            return _entities.Where(x => !x.IsDeleted).Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<T> Read()
        {
            //return new List<Person>(_entities);
            return _entities.Where(x => !x.IsDeleted).ToList();
        }

        public void Update(int id, T entity)
        {
            if (Delete(id))
            {
                entity.Id = id;
                _entities.Add(entity);
            }
        }
    }
}
