using System;

namespace Events
{
    public class TypeWithLotsOfEvents
    {
        protected static EventKey FooEventKey = new EventKey();

        private readonly EventSet _eventSet = new EventSet();
 
        protected EventSet EventSet
        {
            get { return _eventSet; }
        }

        public event EventHandler<EventArgs> Foo
        {
            add { _eventSet.Add(FooEventKey, value); }
            remove { _eventSet.Remove(FooEventKey, value); }
        }

        public void FireFooEvent()
        {
            OnFoo(this, EventArgs.Empty);
        }

        protected virtual void OnFoo(object sender, EventArgs e)
        {
            _eventSet.Raise(FooEventKey, sender, e);
        }
    }
}