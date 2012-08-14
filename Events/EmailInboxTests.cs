using NUnit.Framework;
using Shouldly;

namespace Events
{
    [TestFixture]
    public class EmailInboxTests
    {
        private int _newEmailCount;

        [Test]
        public void TestNewEmailEvent()
        {
            var emailInbox = new EmailInbox();

            emailInbox.NewEmail += EmailInboxNewEmail1;
            emailInbox.NewEmail += EmailInboxNewEmail2;

            emailInbox.Receive();

            _newEmailCount.ShouldBe(2);

            emailInbox.NewEmail -= EmailInboxNewEmail1;

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);

            emailInbox.NewEmail -= EmailInboxNewEmail2;

            emailInbox.Receive();

            _newEmailCount.ShouldBe(3);
        }

        private void EmailInboxNewEmail1(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInbox>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }

        private void EmailInboxNewEmail2(object sender, NewEmailEventArgs e)
        {
            sender.ShouldBeTypeOf<EmailInbox>();

            e.Subject.ShouldNotBeEmpty();
            e.Body.ShouldNotBeEmpty();

            _newEmailCount++;
        }
    }
}