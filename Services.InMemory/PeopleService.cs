using Models;
using Services.Interfaces;

namespace Services.InMemory
{
    //: - implementacja interfejsu
    public class PeopleService : IPeopleService
    {
        private readonly ICollection<Person> _people;

        public PeopleService()
        {
            _people = new List<Person>();
        }

        public int Create(Person entity)
        {
            int id = 0;
            foreach (var person in _people)
            {
                if (person.Id > id)
                    id = person.Id;
            }
            id += 1;

            entity.Id = id;
            _people.Add(entity);

            return id;
        }

        public bool Delete(int id)
        {
            var entity = Read(id);
            if (entity != null)
            {
                return _people.Remove(entity);
            }
            return false;
        }

        public Person? Read(int id)
        {
            foreach (var entity in _people)
            {
                if(entity.Id == id)
                    return entity;
            }
            return null;
        }

        public IEnumerable<Person> Read()
        {
            return new List<Person>(_people);
        }

        public void Update(int id, Person entity)
        {
            if (Delete(id))
            {
                entity.Id = id;
                _people.Add(entity);
            }
        }
    }
}