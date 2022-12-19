using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    //delegaty to wskaźniki na funkcje
    public class DelegatesExample
    {
        public delegate void VoidWithoutParameters();
        public delegate void VoidWithStringParameter(string someString);
        public delegate bool BoolWithTwoIntParameters(int x, int y);

        public void Func1()
        {
            Console.WriteLine("1");
        }

        //@ - pozwala użyć zastrzeżonej nazwy dla zminnych
        public void Func2(string @string)
        {
            Console.WriteLine(@string);
        }

        public bool Func3(int a, int b)
        {
            Console.WriteLine("a = " + a + " ,b = " + b);
            return a == b;
        }

        public BoolWithTwoIntParameters Delegate3 { get; set; }

        public void Test()
        {
            VoidWithoutParameters delegate1 = new VoidWithoutParameters(Func1);

            Func1();
            delegate1();


            VoidWithStringParameter delegate2 = null;
            delegate2 = Func2;

            /*if(delegate2 != null)
                delegate2("Hello");*/

            // ? - operator sprawdzający czy obiekt jest null
            delegate2?.Invoke("Hello!");

            Delegate3 = Func3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var result = Delegate3(i, j);
                    if(result)
                        Console.WriteLine("==");
                }
            }

            Check(Func3, 4, 6);
        }

        public void Check(BoolWithTwoIntParameters @delegate, int a, int b)
        {
            @delegate?.Invoke(a, b);
        }
    }
}
