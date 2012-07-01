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
    }
}
