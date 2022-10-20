using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{

    public class Factorial
    {
        public static int calculateFactorial(int n)
        {
            if (n == 1) return 1;

            return n * calculateFactorial(n - 1);
        }
    }

}