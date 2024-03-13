using System.Net.Mail;

namespace BuilderDesignPattern
{
    internal sealed  class SmtpEmailService
    {
        public async Task SendEmailAsync(string mailTo, string mailFrom, string  subject, string body, List<string> bccs)
        {
            using(var smtp = new SmtpClient("localhost", 25))
            {
                using(var mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailFrom);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.To.Add(mailTo);
                    bccs.ForEach(bcc => mail.Bcc.Add(bcc));
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
