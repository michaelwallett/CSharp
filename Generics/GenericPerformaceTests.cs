using System.Collections;
using System.Collections.Generic;
using Common;
using NUnit.Framework;

namespace Generics
{
    [TestFixture]
    public class GenericPerformaceTests
    {
        private const int Count = 1000000;

        [Test]
        public void TestValueTypePerformace()
        {
            using (new OperationTimer("List<int>"))
            {
                var l = new List<int>(Count);

                for (int i = 0; i < Count; i++)
                {
                    l.Add(i);
                    int x = l[i];
                }

                l = null;
            }

            using (new OperationTimer("ArrayList of In32"))
            {
                var a = new ArrayList(Count);

                for (int i = 0; i < Count; i++)
                {
                    a.Add(i);
                    int x = (int)a[i];
                }

                a = null;
            }
        }

        [Test]
        public void TestReferenceTypePerformance()
        {
            using (new OperationTimer("List<string>"))
            {
                var l = new List<string>(Count);

                for (int i = 0; i < Count; i++)
                {
                    l.Add("X");
                    string x = l[i];
                }

                l = null;
            }

            using (new OperationTimer("ArrayList of String"))
            {
                var a = new ArrayList(Count);

                for (int i = 0; i < Count; i++)
                {
                    a.Add("X");
                    string x = (string)a[i];
                }

                a = null;
            }
        }
    }
}