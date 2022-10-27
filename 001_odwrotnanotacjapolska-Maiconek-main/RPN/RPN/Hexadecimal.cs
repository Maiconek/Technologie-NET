using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    public class Hexadecimal
    {
        public static int hexadecimalToDecimal(String input)
        {
            int len = input.Length;

           
            int base1 = 1;

            int decimal_value = 0;

            // przechodzenie przez stringa
            for (int i = len - 1; i >= 0; i--)
            {
                // jezeli znak znajduje się miedzy '0'-'9',
                // zmieniamy go na inta
                // by subtracting 48 from ASCII value
                if (input[i] >= '0' && input[i] <= '9')
                {
                    decimal_value += (input[i] - 48) * base1;

                    // inkrementacja base1
                    base1 = base1 * 16;
                }

                // jezeli znak znajduje się miedzy 'A'-'F' ,
                // zmieniamy go na jego wartosc int zgodną z ASCII
                else if (input[i] >= 'A' && input[i] <= 'F')
                {
                    decimal_value += (input[i] - 55) * base1;

                    base1 = base1 * 16;
                }
                else {
                    throw new FormatException();
                }
            }
            return decimal_value;
        }
    }
}
