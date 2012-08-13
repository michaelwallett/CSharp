using NUnit.Framework;
using Shouldly;

namespace Events
{
    [TestFixture]
    public class EmailInboxCompilerVersionTests
    {
        private int _newEmailCount;

        [Test]
        public void TestRegisteringForNewEmail()
        {
            var emailInbox = new EmailInboxCompilerVersion();

            emailInbox.AddNewEmail(EmailInboxCompilerVersion_NewEmail1);
            emailInbox.AddNewEmail(EmailInboxCompilerVersion_NewEmail2);

            emailInbox.Receive();

            _newEmailCount.ShouldBe(2);

            emailInbox.RemoveNewEmail(EmailInboxCompilerVersion_NewEmail1);

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);

            emailInbox.RemoveNewEmail(EmailInboxCompilerVersion_NewEmail2);

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);
        }

        private void EmailInboxCompilerVersion_NewEmail1(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInboxCompilerVersion>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }

        private void EmailInboxCompilerVersion_NewEmail2(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInboxCompilerVersion>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }
    }
}