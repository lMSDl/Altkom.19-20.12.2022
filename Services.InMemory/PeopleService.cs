using Models;
using Services.Interfaces;

namespace Services.InMemory
{
    // : <klasa nadrzędna>, <interfejs1>, <interfejs2> ... <<interfejsN>>
    public class PeopleService : EntityService<Person>, IPeopleService
    {
        public IEnumerable<Person> FindByName(string input)
        {
            return _entities.Where(x => !x.IsDeleted).Where(x => x.Name.Contains(input)).ToList();
        }
    }
}