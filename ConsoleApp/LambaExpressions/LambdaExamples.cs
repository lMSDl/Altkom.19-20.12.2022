using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambaExpressions
{
    public class LambdaExamples
    {

        Func<int, int, int> Calculator { get; set; }
        Func<string> SomeFunc { get; set; }
        Action<int> SomeAction { get; set; }
        Action AnotherAction { get; set; }
        
        //wyrażenie lambda
        //<opcjonalny parametr> <operator> <ciało>
        // (a, b) => {}


        public void Test()
        {
            //Calculator += Plus;
            Calculator += //delegate (int a, int b) { return a + b; };
                          //(int a, int b) => { return a + b; };
                          //(a, b) => { return a + b; };
                          (a, b) => a + b;

            SomeFunc += //delegate { return "Hello!"; };
                        () => "Hello!";

            SomeAction += //delegate (int a) { Console.WriteLine(a); };
                            //(a) => Console.WriteLine(a);
                            a => Console.WriteLine(a);

            AnotherAction += //delegate { Console.WriteLine(); };
                            () => Console.WriteLine();


            SomeMethod(x => Console.WriteLine(x.ToUpper()), "Hi!");
        }

        private int Plus(int a, int b) {
            return a + b;
        }



        void SomeMethod(Action<string> stringAction, string value)
        {
            stringAction?.Invoke(value);
        }
    }
}
