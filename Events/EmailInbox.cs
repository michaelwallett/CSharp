using System;

namespace Events
{
    public class EmailInbox
    {
        public event EventHandler<NewEmailEventArgs> NewEmail;

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