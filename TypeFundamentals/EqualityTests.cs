using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace TypeFundamentals
{
    public class EqualityTests
    {
        [TestFixture]
        public class When_comparing_objects_that_are_equal
        {
            private readonly object _x = new Point(1, 2);
            private readonly object _y = new Point(1, 2);
            private readonly object _z = new Point(1, 2);

            [Test]
            public void they_should_be_reflective()
            {
                _x.Equals(_x).ShouldBe(true);
            }

            [Test]
            public void they_should_be_symmetric()
            {
                _x.Equals(_y).ShouldBe(true);
                _y.Equals(_x).ShouldBe(true);
            }

            [Test]
            public void they_should_be_transitive()
            {
                _x.Equals(_y).ShouldBe(true);
                _y.Equals(_z).ShouldBe(true);
                _x.Equals(_y).ShouldBe(true);
            }

            [Test]
            public void they_should_be_consistent()
            {
                _x.Equals(_x).ShouldBe(true);
                _x.Equals(_x).ShouldBe(true);
            }

            [Test]
            public void they_should_return_the_same_hash_code()
            {
                _x.GetHashCode().ShouldBe(_y.GetHashCode());
            }
        }

        [TestFixture]
        public class When_comparing_objects_that_are_not_equal
        {
            private readonly object _x = new Point(1, 2);
            private readonly object _y = new Point(2, 3);
            private readonly object _z = new Point(3, 4);

            [Test]
            public void they_should_not_be_symmetric()
            {
                _x.Equals(_y).ShouldBe(false);
                _y.Equals(_x).ShouldBe(false);
            }

            [Test]
            public void they_should_not_be_transitive()
            {
                _x.Equals(_y).ShouldBe(false);
                _y.Equals(_z).ShouldBe(false);
                _x.Equals(_y).ShouldBe(false);
            }

            [Test]
            public void they_should_not_return_the_same_hash_code()
            {
                _x.GetHashCode().ShouldNotBe(_y.GetHashCode());
            }
        }

        [TestFixture]
        public class When_comparing_two_objects_that_are_the_same_using_the_equals_operator_overload
        {
            private readonly Point _x = new Point(1, 2);
            private readonly Point _y = new Point(1, 2);

            [Test]
            public void they_should_be_equal()
            {
                (_x == _y).ShouldBe(true);
            }
        }

        [TestFixture]
        public class When_comparing_two_different_objects_with_the_not_equal_operator_overload
        {
            private readonly Point _x = new Point(1, 2);
            private readonly Point _y = new Point(2, 3);

            [Test]
            public void they_should_not_be_equal()
            {
                (_x != _y).ShouldBe(true);
            }
        }

        [TestFixture]
        public class When_comparing_an_object_to_null
        {
            private readonly object _x = new Point(1, 2);

            [Test]
            public void they_should_be_not_be_equal()
            {
                _x.Equals(null).ShouldBe(false);
                (_x == null).ShouldBe(false);
            }
        }

        public sealed class Point : IEquatable<Point>
        {
            private readonly int _x;
            private readonly int _y;

            public Point(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public static bool operator ==(Point x, Point y)
            {
                if (Object.ReferenceEquals(x, y)) { return true; }

                return x.Equals(y);
            }

            public static bool operator !=(Point x, Point y)
            {
                return !(x == y);
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Point);
            }

            public bool Equals(Point other)
            {
                if (other == null) { return false; }

                if (Object.ReferenceEquals(this, other)) { return true; }

                return _x.Equals(other._x) && _y.Equals(other._y);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 17;

                    hashCode = (hashCode * 23) + _x.GetHashCode();
                    hashCode = (hashCode * 23) + _y.GetHashCode();

                    return hashCode;
                }
            }
        }
    }
}
