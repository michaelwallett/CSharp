using System;
using System.Collections.Generic;
using System.Threading;

namespace Events
{
    public class EventSet
    {
        private readonly IDictionary<EventKey, Delegate> _events = new Dictionary<EventKey,Delegate>();

        public void Add(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(_events);

            Delegate currentHandler;

            _events.TryGetValue(eventKey, out currentHandler);

            _events[eventKey] = Delegate.Combine(currentHandler, handler);

            Monitor.Exit(_events);
        }

        public void Remove(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(_events);

            Delegate currentHandler;

            if (_events.TryGetValue(eventKey, out currentHandler))
            {
                Delegate newHandler = Delegate.Remove(currentHandler, handler);

                if (newHandler == null)
                {
                    _events.Remove(eventKey);
                }
                else
                {
                    _events[eventKey] = newHandler;
                }
            }

            Monitor.Exit(_events);
        }

        public void Raise(EventKey eventKey, object sender, EventArgs e)
        {
            Delegate currentHandler;

            Monitor.Enter(_events);

            _events.TryGetValue(eventKey, out currentHandler);

            Monitor.Exit(_events);

            if (currentHandler == null)
            {
                return;
            }

            currentHandler.DynamicInvoke(sender, e);
        }
    }
}