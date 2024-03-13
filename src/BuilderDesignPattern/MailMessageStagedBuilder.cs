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
        private string _sender;
        private string _recipient;
        private string _subject;
        private string _message;

        private MailMessageStagedBuilder()
        {
        }

        public static ISenderStage CreateMailMessage()
        {
            return new MailMessageStagedBuilder();
        }

        public IRecepientStage AddSender(string sender)
        {
            _sender = sender;
            return this;
        }

        public ISubjectStage AddRecipient(string recipient)
        {
            _recipient = recipient;
            return this;
        }

        public IMessageStage WithSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public IMailMessageInitializationStage WithMessage(string message)
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
