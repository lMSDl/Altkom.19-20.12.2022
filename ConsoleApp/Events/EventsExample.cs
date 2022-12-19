using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Events
{
    public class EventsExample
    {
        

        public delegate void OddNumber();
        public event OddNumber OddNumberEvent;

        public OddNumber OddNumberDelegate { get; set; }

        public void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);

            if(result % 2 != 0)
            {
                OddNumberDelegate?.Invoke();
                OddNumberEvent?.Invoke();
            }
        }

        private int _counter;

        public EventsExample()
        {
            OddNumberDelegate += CountOdd;
            OddNumberEvent += CountOdd;
        }

        private void CountOdd()
        {
            _counter++;
        }


        public void Test()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Add(i, j);
                }
            }

            Console.WriteLine("Counter: " + _counter);
        }
    }
}
