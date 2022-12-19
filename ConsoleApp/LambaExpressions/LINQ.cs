using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambaExpressions
{
    public class LINQ
    {
        int[] numbers = new[] { 1, 2, 5, 7, 3, 8, 0, 9 };
        IEnumerable<string> strings = "Ala ma kota i dwa psy".Split(' ').ToList();

        IEnumerable<Person> People = new List<Person>()
        {
            new Person { FirstName = "Adam", LastName = "Adamski", Age = 23 },
            new Person { FirstName = "Ewa", LastName = "Adamska", Age = 32 },
            new Person { FirstName = "Adam", LastName = "Ewowski", Age = 35 },
            new Person { FirstName = "Ewa", LastName = "Ewowska", Age = 63 },
            new Person { FirstName = "Piotr", LastName = "Piotrowski", Age = 33 },
            new Person { FirstName = "Piotr", LastName = "Adamski", Age = 66 },
            new Person { FirstName = "Ewa", LastName = "Piotrowska", Age = 72 },
            new Person { FirstName = "Piotr", LastName = "Ewowski", Age = 42 },
        };


        public void Test()
        {

            var query1 = from value in numbers where value > 4 select value;
            var query2 = from value in numbers where value > 4 orderby value descending select value;
            var query3 = from person in People where person.Age > 35 select (person.FirstName + " " + person.LastName);

            query1 = numbers.Where(value => value > 4).Select(value => value);
            query2 = numbers.Where(value => value > 4).OrderByDescending(value => value);
            query3 = People.Where(x => x.Age > 35).Select(x => x.FirstName + " " + x.LastName);

            var result3 = query3.ToList(); //kończy zapytanie i zwraca kolekcję

            var result4 = People.Where(x => x.FirstName == "Adam")//.Single(); //kończy zapytanie i zwraca JEDEN rezultat 
                                                                  // .SingleOrDefault(); //orDefault = jeśli nie znaleziono to zwraca wartość domyślną
                                                                  //.First(); // -||- i zwraca pierwszy znaleziony
                                                                   .FirstOrDefault();
            //.Last(); // -||- ostatni znaleziony
            //.LastOrDefault();

            var result5 = People.Select(x => x.Age).Average();

            var result6 = People.Skip(1).Take(4).ToList();

            var result7 = strings.Where(x => x.Length > 3).Where(x => x.Contains("a")).OrderBy(x => x).ToList();


            //1. posortować kolekcję strings po ilości liter w wyrazach
            var result8 = strings.OrderBy(x => x.Length).ThenByDescending(x => x).ToList();
            //2. Zsumować wartości kolekcji numbers
            var result9 = numbers.Sum();
            //3. Z People wybrać osoby, które mają na imię Piotr lub Ewa
            var result10 = People.Where(person => person.FirstName == "Piotr" || person.FirstName == "Ewa").ToList();
            //4. z People wybrać osoby w wieku 50+ i wybrać ich nazwisko małymi literami
            var result11 = People.Where(x => x.Age > 50)
                                 .Select(x => x.LastName.ToLower())
                                 /*.Select(x => x.LastName)
                                 .Select(x => x.ToLower())*/
                                 .ToList();
            //5. wybrać pojedynczą osobę z imieniem dłuższym niż 3 znaki
            var result12 = People.Where(x => x.FirstName.Length > 3).Last();
        }


    }
}
