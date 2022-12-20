using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEntityService<T>
    {
        //brak kodyfikatora dotępu w interfejsie = public
        int Create(T entity);
        T? Read(int id);
        IEnumerable<T> Read();
        void Update(int id, T entity);
        bool Delete(int id);
    }
}
