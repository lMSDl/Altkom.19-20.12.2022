using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class OperatorsExample
    {

        public static void Test()
        {
            Nullable<int> a = null;
            int? b = 5;
            int c;


            if(a - b == 0 || a - b == null)
            {
                // ?? jeśli wartość po lewej jest null, to użyj wartości po prawej
                c = (a + b) ?? 0;
            }
            else
            {
                //var - typ zmiennej zostanie pobrany z wyniku prawej strony instrukcji inicjalizacji
                var result = a - b; //(int?)

                //if (result != null)
                if (result.HasValue)
                        c = result.Value;
                else
                    c = 0;

                c = result.HasValue ? result.Value : 0;
            }

            c = (a - b == 0 || a - b == null) ? (a + b) ?? 0 : (a - b) ?? 0;
            c = ((a - b == 0 || a - b == null) ? (a + b) : (a - b)) ?? 0 ;

            

        }
    }
}
