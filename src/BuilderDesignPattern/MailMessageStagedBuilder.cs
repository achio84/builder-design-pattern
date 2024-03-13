using System.Net.Mail;

namespace BuilderDesignPattern
{
    internal class MailMessageStagedBuilder: 
        ISenderStage,
        IRecepientStage,
        ISubjectStage,
        IMessageStage,
        IMailMessageInitializationStage
    {
        private MailMessage _mailMessage;
        private MailMessageStagedBuilder()
        {
            _mailMessage = new MailMessage();
        }

        public static ISenderStage CreateMailMessage()
        {
            return new MailMessageStagedBuilder();
        }

        public IRecepientStage AddSender(string sender)
        {
            _mailMessage.From = new MailAddress(sender);
            return this;
        }

        public ISubjectStage AddRecipient(string recipient)
        {
            _mailMessage.To.Add(new MailAddress(recipient));
            return this;
        }

        public IMessageStage WithSubject(string subject)
        {
            _mailMessage.Subject = subject;
            return this;
        }

        public IMailMessageInitializationStage WithMessage(string message)
        {
            _mailMessage.Body = message;
            return this;
        }

        public MailMessage Build()
        {
            return _mailMessage;
        }
    }

    public interface ISenderStage
    {
        public IRecepientStage AddSender(string sender);
    }

    public interface IRecepientStage
    {
        public ISubjectStage AddRecipient(string  recipient);
    }

    public interface ISubjectStage
    {
        public IMessageStage WithSubject(string subject);
    }

    public interface IMessageStage
    {
        public IMailMessageInitializationStage WithMessage(string message);
    }

    public interface IMailMessageInitializationStage
    {
        public MailMessage Build();
    }
}
