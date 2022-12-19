using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Person
    {

        /*private string _firstName = "";
protected void SetFirstName(string value)
{
_firstName = value;
}
public string GetFirstName()
{
return _firstName;
}*/

        //auto-property
        //możemy obniżać poziom dostępności gettera lub settera
        //możemy nadawać wartość początkową dla właściwości
        public string FirstName { get; internal set; } = "";

        //backfield - pole zapasowe dla full-property
        private string lastName = "";
        //full-property
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                //value - nazwa parametru przekazywanego do settera
                lastName = value.ToUpper();
                Console.WriteLine("Zmieniono nazwisko");
            }
        }

        //read-only property - wartość możemy nadać podczas tworzenia obiektu
        public DateTime CreatedAt { get; } = DateTime.Now;

        //właściwość tylko do odczytu + generacja przy dostępie (wartość nie będzie skłądowana w pamięci)
        public string Name => FirstName + " " + LastName;
        
        public Person()
        {
            CreatedAt = DateTime.Now;
        }

        public void DoSth()
        {
            //CreatedAt = CreatedAt.AddDays(1); //nie można zmodyfikować wartości po wyjściu z konstruktora (read-only property)
            Console.WriteLine(Name);
        }
         
        public int Age { get; set; }
    }
}
