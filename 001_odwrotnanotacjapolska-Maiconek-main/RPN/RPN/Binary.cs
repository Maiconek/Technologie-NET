using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    public class Binary
    {
        public static int binaryToDecimal(int n)
        {
            int num = n;
            
            int decimal_value = 0;
            int base1 = 1;

            int temp = num;
            while (temp > 0)
            {
                
                int last_digit = temp % 10; // bierzemy ostatnią cyfre w podanej liczbie
                
                if (last_digit > 1 || last_digit < 0) { // sprawdzamy czy spełnia założenia
                    throw new FormatException(); // jak nie to wyjątek
                }
                
                temp = temp / 10; // usuwamy ostatnią cyfre z podanej liczby

                decimal_value += last_digit * base1;

                base1 = base1 * 2;
            }

            return decimal_value;
        }
    }
}
