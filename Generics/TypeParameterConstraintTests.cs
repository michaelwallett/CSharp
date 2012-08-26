using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using Shouldly;

namespace Generics
{
    [TestFixture]
    public class TypeParameterConstraintTests
    {
        [Test]
        public void TestTypeParameterConstraints()
        {
            IList<string> list = new List<string>();
            list.Add("X");

            Convert<string, object>(list).First().ShouldBe("X");
            Convert<string, IComparable>(list).First().ShouldBe("X");
            Convert<string, IComparable<string>>(list).First().ShouldBe("X");
            Convert<string, string>(list).First().ShouldBe("X");

            // Error - No implicit conversion from string to Exception.
            //Convert<string, Exception>(list).First().ShouldBe("X");
        }

        private static List<TResult> Convert<T, TResult>(IList<T> list) where T : TResult
        {
            var results = new List<TResult>(list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                results.Add(list[i]);
            }

            return results;
        }
    }
}
