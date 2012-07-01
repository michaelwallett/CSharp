using System;
using NUnit.Framework;
using Shouldly;

namespace TypeFundamentals
{
    [TestFixture]
    public class CheckedUncheckedTests
    {
        [Test]
        public void OverflowThrowsAnExceptionWithCheckedOperation()
        {
            Should.Throw<OverflowException>(ByteOverflowWithCheckedOperator);
            Should.Throw<OverflowException>(ByteOverflowWithCheckedStatement);
        }

        private void ByteOverflowWithCheckedOperator()
        {
            byte i = byte.MaxValue;
            i = checked((byte)(i + 1));
        }

        private void ByteOverflowWithCheckedStatement()
        {
            byte i = byte.MaxValue;

            checked
            {
                i += 1;
            }
        }

        [Test]
        public void OverflowDoesNotThrowAnExceptionWithUncheckedOperation()
        {
            // unchecked operator
            byte i = byte.MaxValue;

            i = unchecked((byte)(i + 1));

            i.ShouldBe(byte.MinValue);

            // unchecked statement
            i = byte.MaxValue;

            unchecked
            {
                i += 1;
            }

            i.ShouldBe(byte.MinValue);
        }

        [Test]
        public void OverflowThrowsAnExceptionForDecimalEvenWithUncheckedOperator()
        {
            decimal i = decimal.MaxValue;

            Should.Throw<OverflowException>(() => i = unchecked(i + 1));
        }
    }
}