using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Methods
{
    [TestFixture]
    public class PartialMethodTests
    {
        [Test]
        public void TestPartialMethod()
        {
            Customer customer = new Customer("Mike");

            customer.Name = "Michael";
        }
    }

    public partial class Customer
    {
        private string _name;

        public Customer(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                OnNameChanging(_name, value);

                _name = value;
            }
        }

        partial void OnNameChanging(string originalName, string newName);
    }

    public partial class Customer
    {
        partial void OnNameChanging(string originalName, string newName)
        {
            Debug.WriteLine("Name changed from '{0}' to '{1}'.", originalName, newName);
        }
    }
}
