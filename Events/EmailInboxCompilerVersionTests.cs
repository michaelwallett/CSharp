using NUnit.Framework;
using Shouldly;

namespace Events
{
    [TestFixture]
    public class EmailInboxCompilerVersionTests
    {
        private int _newEmailCount;

        [Test]
        public void TestNewEmailEvent()
        {
            var emailInbox = new EmailInboxCompilerVersion();

            emailInbox.AddNewEmail(EmailInboxCompilerVersionNewEmail1);
            emailInbox.AddNewEmail(EmailInboxCompilerVersionNewEmail2);

            emailInbox.Receive();

            _newEmailCount.ShouldBe(2);

            emailInbox.RemoveNewEmail(EmailInboxCompilerVersionNewEmail1);

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);

            emailInbox.RemoveNewEmail(EmailInboxCompilerVersionNewEmail2);

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);
        }

        private void EmailInboxCompilerVersionNewEmail1(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInboxCompilerVersion>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }

        private void EmailInboxCompilerVersionNewEmail2(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInboxCompilerVersion>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }
    }
}