using System;
using System.Threading;

namespace Events
{
    public class EmailInboxCompilerVersion
    {
        private EventHandler<NewEmailEventArgs> NewEmail;

        // The compiler will generate a method called add_NewEmail
        public void AddNewEmail(EventHandler<NewEmailEventArgs> value)
        {
            EventHandler<NewEmailEventArgs> currentHandler = NewEmail;
            EventHandler<NewEmailEventArgs> previousHandler;

            do
            {
                previousHandler = currentHandler;

                var newHandler = (EventHandler<NewEmailEventArgs>)Delegate.Combine(previousHandler, value);

                currentHandler = Interlocked.CompareExchange(ref NewEmail, newHandler, previousHandler);
            }
            while (currentHandler != previousHandler);
        }

        // The compiler will generate a method called remove_NewEmail
        public void RemoveNewEmail(EventHandler<NewEmailEventArgs> value)
        {
            EventHandler<NewEmailEventArgs> currentHandler = NewEmail;
            EventHandler<NewEmailEventArgs> previousHandler;

            do
            {
                previousHandler = currentHandler;

                var newHandler = (EventHandler<NewEmailEventArgs>)Delegate.Remove(previousHandler, value);

                currentHandler = Interlocked.CompareExchange(ref NewEmail, newHandler, previousHandler);
            }
            while (currentHandler != previousHandler);
        }

        public void Receive()
        {
            OnNewEmail(new NewEmailEventArgs("Subject", "Body"));
        }

        protected virtual void OnNewEmail(NewEmailEventArgs e)
        {
            EventHandler<NewEmailEventArgs> handler = NewEmail;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}