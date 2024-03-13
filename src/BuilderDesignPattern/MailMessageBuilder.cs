using System.Net.Mail;

namespace BuilderDesignPattern
{
    internal sealed class MailMessageBuilder
    {
        private MailMessage mailMessage;
        public MailMessageBuilder() 
        {
            mailMessage = new MailMessage();
        }

        public MailMessageBuilder AddSender(string sender)
        {
            mailMessage.From = new MailAddress(sender);
            return this;
        }

        public MailMessageBuilder AddRecipient(string mailTo)
        {
            mailMessage.To.Add(new MailAddress(mailTo));
            return this;
        }

        public MailMessageBuilder WithSubject(string subject)
        {
            mailMessage.Subject = subject;
            return this;
        }

        public MailMessageBuilder WithMessage(string message)
        {
            mailMessage.Body = message;
            return this;
        }

        public MailMessage Build()
        {
            return mailMessage;
        }
    }
}
