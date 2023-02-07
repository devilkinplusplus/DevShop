using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Application.Abstractions.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace DevShop.Infrastructure
{
    public class MailService : IMailService
    {
        public async Task SendMail(string from,string passwordFromSender,string to,string message)
        {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = "Thanks for your feadback";
                email.Body = new TextPart(TextFormat.Plain) { Text = message };

                // send email
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(from, passwordFromSender);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
        }
    }
}