using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class MulticastDelegateExample
    {
        public delegate void MuticastDelegate(string @string);

        public void Message1(string message)
        {
            Console.WriteLine("1st message: " + message);
        }
        public void Message2(string message)
        {
            Console.WriteLine("2nd message: " + message);
        }
        public void Message3(string message)
        {
            Console.WriteLine("3rd message: " + message);
        }


        public void Test()
        {
            MuticastDelegate @delegate = null;

            //+= - podpinamy kolejne funkcje
            @delegate += Message1;
            @delegate += Message2;
            @delegate += Message3;
            @delegate += Console.WriteLine;

            @delegate("Hello!");

            @delegate -= Message2;

            @delegate("Hi!");

            //= - zastępuje wszystkie funkcje, tą jędną wskazaną
            @delegate = Console.WriteLine;
            @delegate("console");
        }
    }
}
