using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeFundamentals
{
    public static class AStaticClass
    {
        private static string aStaticField;

        public static void AStaticMethod() { }

        public static string AStaticProperty
        {
            get { return aStaticField; }
            set { aStaticField = value; }
        }

        public static event EventHandler AStaticEvent;
    }
}
