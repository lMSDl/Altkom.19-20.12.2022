//global using - używanie wskazanej przestrzeni nazw na przestrzeni całego projektu
global using System;
using ConsoleApp.Delegates;
using ConsoleApp.Events;
using ConsoleApp.LambaExpressions;
using ConsoleApp.Models;

//namespace ConsoleApp
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

Console.WriteLine("Hello, World!");
            DoSth();
            
            void DoSth()
            {
                Console.WriteLine("I am working..");
            }


int? a = 4;
a = null;

object? b = new object();

b = SetValue();

if (b != null)
    Console.WriteLine(b.ToString());


static object? SetValue()
{
    return null;
}


Person person = new Person();
person.FirstName = "Ewa";
person.LastName = "ewowska";

Console.WriteLine("Utworzono: " + person.CreatedAt);

Console.WriteLine(person.Name);
person.LastName = "Monikowska";
Console.WriteLine(person.Name);

person.Age = 20;
Console.WriteLine(person.Age);
person.Age += 10;
Console.WriteLine(person.Age);

Pizza pizza1 = new Pizza() { Cheese = true, Sauce = true, Ham = true };
Pizza pizza2 = new Pizza(true, true, true) { Ham = true };

Console.WriteLine("-----------");

new DelegatesExample().Test();
Console.WriteLine("-----------");
new MulticastDelegateExample().Test();
Console.WriteLine("-----------");
EventsExample eventsExample = new EventsExample();
eventsExample.OddNumberDelegate += Odd;
eventsExample.OddNumberEvent += Odd;

eventsExample.Test();
Console.WriteLine("-----------");
new BuildInDelegates().Test();

Console.WriteLine("-----------");

new LINQ().Test();


void Odd()
{
    Console.WriteLine("!!!");
}


//        }
//   }
//}