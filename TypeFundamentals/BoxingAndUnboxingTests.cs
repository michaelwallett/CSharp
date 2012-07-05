using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace TypeFundamentals
{
    [TestFixture]
    public class BoxingAndUnboxingTests
    {
        [Test]
        public void AValueTypeCannotBeUnboxedToADifferentType()
        {
            int x = 1;

            // Box x
            // 1) Allocate required memory on heap.
            // 2) Copy fields to allocated memory.
            // 3) Return a pointer to the object.
            object o = x;
                          
            short y;

            // Unbox o
            Should.Throw<InvalidCastException>(() => y = (short)o);
        }

        [Test]
        public void BoxingAndUnboxingExample()
        {
            Point p = new Point(1, 1);
            p.ToString().ShouldBe("1, 1");

            p.Change(2, 2);
            p.ToString().ShouldBe("2, 2");

            object o = p;
            o.ToString().ShouldBe("2, 2");

            ((Point)o).Change(3, 3);
            o.ToString().ShouldBe("2, 2");

            // Box p. Change the boxed object and discard it.
            ((IChangeBoxedPoint)p).Change(4, 4);
            p.ToString().ShouldBe("2, 2");

            // Change the already boxed object on the heap.
            ((IChangeBoxedPoint)o).Change(5, 5);
            o.ToString().ShouldBe("5, 5");
        }

        public interface IChangeBoxedPoint
        {
            void Change(int x, int y);
        }

        public struct Point : IChangeBoxedPoint
        {
            private int _x;
            private int _y;

            public Point(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public void Change(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public override string ToString()
            {
                return string.Format("{0}, {1}", _x, _y);
            }
        }
    }
}
