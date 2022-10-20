using NUnit.Framework;
using System;
using RPNCalculator;

namespace RPNTest {
	[TestFixture]
	public class RPNTest {
		private RPN _sut;
		[SetUp]
		public void Setup() {
			_sut = new RPN();
		}
		[Test]
		public void CheckIfTestWorks() {
			Assert.Pass();
		}

		[Test]
		public void CheckIfCanCreateSut() {
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void SingleDigitOneInputOneReturn() {
			var result = _sut.EvalRPN("1");

			Assert.That(result, Is.EqualTo(1));

		}
		[Test]
		public void SingleDigitOtherThenOneInputNumberReturn() {
			var result = _sut.EvalRPN("2");

			Assert.That(result, Is.EqualTo(2));

		}
		[Test]
		public void TwoDigitsNumberInputNumberReturn() {
			var result = _sut.EvalRPN("12");

			Assert.That(result, Is.EqualTo(12));

		}
		[Test]
		public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("1 2"));

		}
		[Test]
		public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 +");

			Assert.That(result, Is.EqualTo(3));
		}
		[Test]
		public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("2 2 *");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 3 -");

			Assert.That(result, Is.EqualTo(2));
		}
		[Test]
		public void ComplexExpression() {
			var result = _sut.EvalRPN("15 7 1 1 + - / 3 * 2 1 1 + + -");

			Assert.That(result, Is.EqualTo(4));
		}

        // Zadanie 1

        // TESTY DLA DZIELENIA
        [Test]
        public void OperatorDivide_DividingTwoNumbers_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("2 8 /");

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void OperatorDivision_DividerBiggerThanDividend_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("8 4 /");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void OperatorDivide_DivideByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _sut.EvalRPN("0 2 /"));
        }


        // TESTY DLA SILNI
        [Test]
        public void OperatorFactorial_SingleDigit_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("3 !");

            Assert.That(result, Is.EqualTo(6));
        }
    
        [Test]
        public void OperatorFactorial_SingleDigitLessThanZero_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("-2 !"));
        }

        [Test]
        public void OperationFactorialAndOperationMultiple_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("2 2 2 * + !");

            Assert.That(result, Is.EqualTo(720));
        }

        // TEST DLA WART. BEZWZGLĘDNEJ
        [Test]
        public void OperatorAbsoulute_SingleDigit()
        {
            var result = _sut.EvalRPN("-5 abs");

            Assert.That(result, Is.EqualTo(5));
        }

        // różne testy dla obsługi wyjątków
        [Test]
        public void EmptyInput_ThrowsExcepton()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN(""));
        }
        [Test]
        public void MissingOperator_ThrowsException() 
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("1 2"));
        }
        [Test]
        public void NumberAndOperatorWithoutSpace_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("2 3+"));
        }
        [Test]
        public void TooLittleNumbers_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("2 +"));
        }
        [Test]
        public void TooMuchNumbers_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("2 2 2 +"));
        }
        [Test]
        public void InputOnlyOperator_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("+"));
        }

        // Testy ze zmianą systemu liczbowego
        [Test]
        public void Converter_BinaryToDecimal_ReturnCorrectResult() {
            var result = _sut.EvalRPN("B01100");

            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Converter_BinaryToDecimal_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("B2"));
        }

        [Test]
        public void Converter_HexadecimalToDecimal_ReturnCorrectResult() 
        {
            var result = _sut.EvalRPN("#AB");

            Assert.That(result, Is.EqualTo(171));

        }
        [Test]
        public void Converter_HexadecimalToDecimal_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("#AG"));
        }
        [Test]
        public void DecimalHexidecimalAddition_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("#BA D13 +");

            Assert.That(result, Is.EqualTo(199));
        }
        [Test]
        public void BinaryDecimalSubstraction_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("B10 D8 -");

            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void BinaryDecimalMultiplication_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("B101 D8 *");

            Assert.That(result, Is.EqualTo(40));
        }
        [Test]
        public void BinaryDecimalDivision_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("B101 D50 /");

            Assert.That(result, Is.EqualTo(10));
        } 
    }
}