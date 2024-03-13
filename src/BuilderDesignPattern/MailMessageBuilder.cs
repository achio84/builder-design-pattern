using System.Net.Mail;

namespace BuilderDesignPattern
{
    internal sealed class MailMessageBuilder
    {
        private string _sender;
        private string _recipient;
        private string _subject;
        private string _message;
        public MailMessageBuilder() 
        {
        }

        public MailMessageBuilder AddSender(string sender)
        {
            _sender = sender;
            return this;
        }

        public MailMessageBuilder AddRecipient(string mailTo)
        {
            _recipient = mailTo;
            return this;
        }

        public MailMessageBuilder WithSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public MailMessageBuilder WithMessage(string message)
        {
            _message = message;
            return this;
        }

        public MailMessage Build()
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(_sender);
            mail.To.Add(new MailAddress(_recipient));
            mail.Subject = _subject;
            mail.Body = _message;

            return mail;
        }
    }
}
