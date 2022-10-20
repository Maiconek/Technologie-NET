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
                
                int last_digit = temp % 10;
                
                if (last_digit > 1 || last_digit < 0) {
                    throw new InvalidOperationException();
                }
                
                temp = temp / 10;

                decimal_value += last_digit * base1;

                base1 = base1 * 2;
            }

            return decimal_value;
        }
    }
}
