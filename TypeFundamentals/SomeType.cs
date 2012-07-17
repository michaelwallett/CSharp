using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeFundamentals
{
    public sealed class SomeType
    {
        private class SomeNestedType { }

        private const int SomeConstant = 1;
        private readonly string SomeReadOnlyField = "2";
        private static int SomeReadWriteField = 3;

        static SomeType() { }

        public SomeType(int x) { }
        public SomeType() { }

        private string InstanceMethod() { return null; }
        public static void Main() { }

        public int SomeProp
        {
            get { return 0; }
            set { }
        }

        public int this[string s]
        {
            get { return 0; }
            set { }
        }

        public event EventHandler SomeEvent;
    }
}
