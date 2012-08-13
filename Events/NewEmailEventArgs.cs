using System;

namespace Events
{
    public class NewEmailEventArgs : EventArgs
    {
        private readonly string _subject;
        private readonly string _body;

        public NewEmailEventArgs(string subject, string body)
        {
            _subject = subject;
            _body = body;
        }

        public string Subject
        {
            get { return _subject; }
        }

        public string Body
        {
            get { return _body; }
        }
    }
}