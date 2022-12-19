using Models;

namespace Services.Interfaces
{
    public interface IPeopleService
    {
        //brak kodyfikatora dotępu w interfejsie = public
        int Create(Person entity);
        Person? Read(int id);
        IEnumerable<Person> Read();
        void Update(int id, Person entity);
        bool Delete(int id);
    }
}