using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace TypeFundamentals
{
    [TestFixture]
    public class DynamicTests
    {
        [Test]
        public void DynamicTest1()
        {
            for (int i = 0; i < 2; i++)
            {
                dynamic arg = i == 0 ? (dynamic)5 : (dynamic)"A";

                dynamic result = Plus(arg);

                M(result);
            }
        }

        private dynamic Plus(dynamic arg)
        {
            return arg + arg;
        }

        private void M(int arg)
        {
            arg.ShouldBe(10);
        }

        private void M(string arg)
        {
            arg.ShouldBe("AA");
        }

        [Test]
        public void DynamicTest2()
        {
            dynamic target = "Michael";
            dynamic arg = "ael";

            bool result = target.Contains(arg);

            result.ShouldBe(true);
        }
    }
}
