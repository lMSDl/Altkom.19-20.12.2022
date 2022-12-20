using Models;

namespace Services.Interfaces
{
    public interface IPeopleService : IEntityService<Person>
    {
        IEnumerable<Person> FindByName(string input);
    }
}