using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RPNCalculator {
	public class RPN {
		private Stack<int> _operators;
		Dictionary<string, Func<int, int, int>> _operationFunction;
        Dictionary<string, Func<int, int>> _operationFunctionSingleNumber; //  _operationFunction dla operacji jednoelementowych

        public int EvalRPN(string input) {
			_operationFunctionSingleNumber = new Dictionary<string, Func<int, int>> // słownik zawierąjcy stringa oraz Func<wejscie, wyjscie>
			{
				["!"] = (fst) => (fst < 0 ? throw new InvalidOperationException() : Factorial.calculateFactorial(fst)),
				["abs"] = (fst) => (Math.Abs(fst)),
			};


            _operationFunction = new Dictionary<string, Func<int, int, int>>
			{
				["+"] = (fst, snd) => (fst + snd),
				["-"] = (fst, snd) => (fst - snd),
				["*"] = (fst, snd) => (fst * snd),
				["/"] = (fst, snd) => snd == 0 ? throw new DivideByZeroException() : fst / snd, 
				// jezeli snd == 0 throw Exception, jezeli nie wykonaj dzielenie
            };

			
			_operators = new Stack<int>();

			var splitInput = input.Split(' ');
			foreach (var op in splitInput)
			{
				if (IsNumber(op))
					_operators.Push(Int32.Parse(op));

                if (op.StartsWith("D")) // jezeli input zaczyna się na daną litere
                {
                    int number = Convert.ToInt32(op.Substring(1, op.Length - 1)); // przekonweruj stringa na inta
					_operators.Push(number); // pushujemy na stos wynik działania
                }
                
				if (op.StartsWith("B"))
                {
                    int number = Convert.ToInt32(op.Substring(1, op.Length - 1));
                    _operators.Push(Binary.binaryToDecimal(number));
                }
                
				if (op.StartsWith("#"))
                {
                    String number = op.Substring(1, op.Length - 1);
                    _operators.Push(Hexadecimal.hexadecimalToDecimal(number));
                }
                
				else
				if (IsOperator(op))
				{
					var num1 = _operators.Pop();
					var num2 = _operators.Pop();
					_operators.Push(_operationFunction[op](num1, num2));
				}

				else
				if (IsOperatorForSingleNumber(op)) // Jeśli znak jest operatorem dla jednego argumentu 
				{
					var num = _operators.Pop(); // Zdejmij ze stosu 
					_operators.Push(_operationFunctionSingleNumber[op](num)); //  na stos wynik działania w _operationFunction wg odczyt. operatora
				}
				


			}	

			var result = _operators.Pop();
			if (_operators.IsEmpty)
			{
				return result;
			}
			throw new InvalidOperationException(); 
		}

        

        private bool IsNumber(String input) => Int32.TryParse(input, out _);

		private bool IsOperator(String input) =>
			input.Equals("+") || input.Equals("-") ||
			input.Equals("*") || input.Equals("/");

		private bool IsOperatorForSingleNumber(String input) =>
			input.Equals("!") || input.Equals("abs");		

        private Func<int, int, int> Operation(String input) =>
			(x, y) =>
			(
				(input.Equals("+") ? x + y :
					(input.Equals("*") ? x * y : int.MinValue)
				)
			);
	}
}