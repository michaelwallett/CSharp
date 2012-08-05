using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace Methods
{
    [TestFixture]
    public class OperatorConversionTests
    {
        [Test]
        public void TestImplictConversion()
        {
            var now = DateTime.Now;

            DateOfBirth dateOfBirth1 = new DateOfBirth(now);
            DateOfBirth dateOfBirth2 = now.Ticks;

            dateOfBirth1.DateTime.ShouldBe(dateOfBirth2.DateTime);
        }

        [Test]
        public void TestExplicitConversion()
        {
            var now = DateTime.Now;

            DateOfBirth dateOfBirth = new DateOfBirth(now);
            long ticks = (long)dateOfBirth;

            now.Ticks.ShouldBe(ticks);

            dateOfBirth.ToIn64().ShouldBe(now.Ticks);
        }
    }

    public class DateOfBirth
    {
        private DateTime _dateOfBirth;

        public DateOfBirth(DateTime value)
        {
            _dateOfBirth = value;
        }

        public DateOfBirth(long ticks)
        {
            _dateOfBirth = new DateTime(ticks);
        }

        public DateTime DateTime
        {
            get { return _dateOfBirth; } 
        }

        public long ToIn64()
        {
            return _dateOfBirth.Ticks;
        }

        public static implicit operator DateOfBirth(long ticks)
        {
            return new DateOfBirth(ticks);
        }

        public static explicit operator long(DateOfBirth dateOfBirth)
        {
            return dateOfBirth.DateTime.Ticks;
        }
    }
}
