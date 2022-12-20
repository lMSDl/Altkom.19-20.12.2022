using Models;
using Services.InMemory;

var person = new Person { Id = 1, Name = "Michał Michałowski", Age = 21 };

Console.WriteLine(person);


var companiesService = new EntityService<Company>();

companiesService.Create(new Company() { Name = "Altkom" });
companiesService.Create(new Company() { Name = "Microsoft" });

var companies = companiesService.Read();


var peopleService = new PeopleService();

peopleService.Create(new Person() { Name = "Adam Adamski", Age = 34 });
peopleService.Create(new Person() { Name = "Ewa Ewowska", Age = 34 });
peopleService.Create(new Person() { Name = "Ewa Adamska", Age = 34 });
peopleService.Create(new Person() { Name = "Adam Ewowski", Age = 34 });

var people = peopleService.FindByName("Adam");

peopleService.Delete(3);
people = peopleService.FindByName("Adam");





Console.ReadLine();

