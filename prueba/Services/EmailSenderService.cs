using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ZooLine.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace ZooLine.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSenderService (IOptions<SmtpSettings>smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

        }
        public async Task SendEmailAsync(MailRequest request)
        {
            try
            { 
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName,_smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress("", request.Email));
                message.Subject = request.Tema;
                message.Body = new TextPart("html") { Text = request.Cuerpo };

                using (var cliente = new MailKit.Net.Smtp.SmtpClient())
                {
                    await cliente.ConnectAsync(_smtpSettings.Server);
                    await cliente.AuthenticateAsync(_smtpSettings.Username,_smtpSettings.Password);
                    await cliente.SendAsync(message);
                    await cliente.DisconnectAsync(true);
                }
            }
            catch(Exception )
            {

            }
        }
    }
}
