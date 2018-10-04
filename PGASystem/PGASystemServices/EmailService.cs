using System;
using MailKit.Net.Smtp;
using MimeKit;
using PGASystemData;

namespace PGASystemServices
{
    public class EmailService : IEmail
    {
        /* This method allows for sending of custom email */
        public void sendEmail(String toEmailAddress, String toName, String subject, String body)
        {
            var message = new MimeMessage();
            /* Google account eie.pg.wits@gmail.com is used to send emails*/
            message.From.Add(new MailboxAddress("PGA System", "eie.pg.wits@gmail.com"));
            message.To.Add(new MailboxAddress(toName, toEmailAddress));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("eie.pg.wits@gmail.com", "Macbook2");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
