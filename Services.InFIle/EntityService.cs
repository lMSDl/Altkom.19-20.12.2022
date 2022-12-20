using Models;
using Services.Interfaces;

namespace Services.InFIle
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        public int Create(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T? Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}