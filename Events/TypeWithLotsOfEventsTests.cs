using System;
using NUnit.Framework;
using Shouldly;

namespace Events
{
    [TestFixture]
    public class TypeWithLotsOfEventsTests
    {
        private int _fooCount;

        [Test]
        public void TestFooEvent()
        {
            var typeWithLotsOfEvents = new TypeWithLotsOfEvents();

            typeWithLotsOfEvents.Foo += TypeWithLotsOfEventsFoo1;
            typeWithLotsOfEvents.Foo += TypeWithLotsOfEventsFoo2;

            typeWithLotsOfEvents.FireFooEvent();

            _fooCount.ShouldBe(2);

            typeWithLotsOfEvents.Foo -= TypeWithLotsOfEventsFoo1;

            typeWithLotsOfEvents.FireFooEvent();

            _fooCount.ShouldBe(3);

            typeWithLotsOfEvents.Foo -= TypeWithLotsOfEventsFoo2;

            typeWithLotsOfEvents.FireFooEvent();

            _fooCount.ShouldBe(3);
        }

        private void TypeWithLotsOfEventsFoo1(object sender, EventArgs e)
        {
            sender.ShouldBeTypeOf<TypeWithLotsOfEvents>();

            _fooCount++;
        }

        private void TypeWithLotsOfEventsFoo2(object sender, EventArgs e)
        {
            sender.ShouldBeTypeOf<TypeWithLotsOfEvents>();

            _fooCount++;
        }
    }
}