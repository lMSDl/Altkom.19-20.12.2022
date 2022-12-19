//global using - używanie wskazanej przestrzeni nazw na przestrzeni całego projektu
global using System;

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



//        }
//   }
//}