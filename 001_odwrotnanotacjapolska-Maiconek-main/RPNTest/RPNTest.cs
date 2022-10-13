using NUnit.Framework;
using System;
using RPNCalulator;

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
        
        [Test]
        public void OperatorDivide_DividingTwoNumbers_ReturnCorrectResult()
        {
            var result = _sut.EvalRPN("2 8 /");

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void SingleDigitFactorial()
        {
            var result = _sut.EvalRPN("3 !");

            Assert.That(result, Is.EqualTo(6));
        }
       
        [Test]
        public void ZeroAfterFactorial()
        {
            var result = _sut.EvalRPN("0 !");

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void OperatorFactorial_FacSingleDigitLessThanZero_ThrowsExcepton()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("-2 !"));
        }

        [Test]
        public void SimpleAbsolute()
        {
            var result = _sut.EvalRPN("-5 ||");

            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void DivideByZero()
        {
            Assert.Throws<DivideByZeroException>(() => _sut.EvalRPN("0 2 /"));
        }
        [Test]
        public void TooLittleNumbers()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("2 +"));
        }
        [Test]
        public void TooMuchNumbers()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("2 2 2 +"));
        }
        [Test]
        public void InputOnlyOperator()
        {
            Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("+"));
        }
		[Test]
		public void BinaryTest()
		{
			var result = _sut.EvalRPN("101 B");

			Assert.That(result, Is.EqualTo(5));
		}
        [Test]
        public void DecimalTest()
        {
            var result = _sut.EvalRPN("10 D");

            Assert.That(result, Is.EqualTo(10));
        }
        
        
        [Test]
        public void DecimalAndBinaryAdditionTest()
        {
            var result = _sut.EvalRPN("10 B 100 D +");

            Assert.That(result, Is.EqualTo(102));
        }
    }
}