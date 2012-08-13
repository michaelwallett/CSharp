using NUnit.Framework;
using Shouldly;

namespace Events
{
    [TestFixture]
    public class EmailInboxTests
    {
        private int _newEmailCount;

        [Test]
        public void TestRegisteringForNewEmail()
        {
            var emailInbox = new EmailInbox();

            emailInbox.NewEmail += EmailInbox_NewEmail1;
            emailInbox.NewEmail += EmailInbox_NewEmail2;

            emailInbox.Receive();

            _newEmailCount.ShouldBe(2);

            emailInbox.NewEmail -= EmailInbox_NewEmail1;

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);

            emailInbox.NewEmail -= EmailInbox_NewEmail2;

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);
        }

        private void EmailInbox_NewEmail1(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInbox>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }

        private void EmailInbox_NewEmail2(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInbox>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }
    }
}