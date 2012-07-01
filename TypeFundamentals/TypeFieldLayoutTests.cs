using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace TypeFundamentals
{
    [TestFixture]
    public class TypeFieldLayoutTests
    {
        [Test]
        public void TypeLayoutCanBeControlledUsingStructLayoutAttribute()
        {
            ValueType value = new ValueType(1, 2);

            value.X.ShouldBe(1);
            value.Y.ShouldBe(2);
        }

        //[StructLayout(LayoutKind.Auto)] If the value type is not being used for unmanaged interop.
        [StructLayout(LayoutKind.Explicit)]
        public struct ValueType
        {
            [FieldOffset(0)]
            private readonly int _x;

            [FieldOffset(4)]
            private readonly int _y;

            public ValueType(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public int X
            {
                get { return _x; }
            }

            public int Y
            {
                get { return _y; }
            }
        }
    }
}
