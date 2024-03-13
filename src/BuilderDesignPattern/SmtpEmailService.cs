using System.Net.Mail;

namespace BuilderDesignPattern
{
    internal sealed  class SmtpEmailService
    {
        public async Task SendEmailAsync(string mailTo, string mailFrom, string  subject, string message)
        {
            using(var smtp = new SmtpClient("localhost", 25))
            {
                var mail = MailMessageStagedBuilder
                    .CreateMailMessage()
                    .AddSender(mailFrom)
                    .AddRecipient(mailTo)
                    .WithSubject(subject)
                    .WithMessage(message)
                    .Build();
                //var builder = new MailMessageBuilder();
                //var mail = builder
                //    .AddSender(mailFrom)
                //    .AddRecipient(mailTo)
                //    .WithSubject(subject)
                //    .WithMessage(message)
                //    .Build();

                await smtp.SendMailAsync(mail);

                //using(var mail = new MailMessage())
                //{
                //    mail.From = new MailAddress(mailFrom);
                //    mail.Subject = subject;
                //    mail.Body = body;
                //    mail.To.Add(mailTo);
                //    bccs.ForEach(bcc => mail.Bcc.Add(bcc));
                //    await smtp.SendMailAsync(mail);
                //}
            }
        }
    }
}
