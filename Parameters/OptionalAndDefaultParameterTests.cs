using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace Parameters
{
    [TestFixture]
    public class OptionalAndDefaultParameterTests
    {
        [Test]
        public void TestOptionalAndDefaultParameters()
        {
            Method(f: 0.1f);
            Method(0.1f, s: "B");
            Method(0.1f, s: "C", i: 10);
            Method(0.1f, 11, "D", DateTime.Now);
        }

        private void Method(float f, int i = 9, string s = "A", DateTime dt = default(DateTime))
        {
            Debug.WriteLine("f={0}, i={1}, s={2}, dt={3}", f, i, s, dt);
        }
    }
}
