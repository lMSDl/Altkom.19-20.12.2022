using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    //Klasa o potencjalnie rozbudowanych konstruktorach (teleskopowych)
    //Właściwości mogą posłużyć do pozbycia się konstruktorów, przez zastąpienie ich inicjalizatorem
    //Możemy korzystać z inicjalizatora w przypadku konstruktora parametrowego i bezparametrowego
    public class Pizza
    {
        //jeżeli istnieje jakiś kontruktor paremetrowy, to bezparametrowy musimy utworzyć osobno
        public Pizza() { }

        public Pizza(bool cheese) {
            Cheese = cheese;
        }
        public Pizza(bool cheese, bool sauce, bool onion)
        {
            Cheese = cheese;
            Sauce = sauce;
            Onion = onion;
        }
        /*public Pizza(bool cheese, bool ham, bool onion)
        {
            Cheese = cheese;
            Ham = ham;
            Onion = onion;
        }*/


        public bool  Cheese { get; set; }
        public bool Sauce { get; set; }
        public bool Ham { get; set; }
        private bool Onion { get; set; }
        public bool Tomato { get; set; }

        /*
         * ....
         */

    }
}
