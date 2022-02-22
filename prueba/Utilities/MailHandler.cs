using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using ZooLine.Models;
using Microsoft.Extensions.Options;
using MailKit.Security;

namespace ZooLine.Utilities
{
    public class MailHandler:IMailHandler
    {
        SmtpSettings _smtpSettings;

        public MailHandler(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

       
        public async Task<bool> SendEmailAsync(SendEmailModel sendEmailModel)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpSettings.SenderName ,_smtpSettings.SenderEmail));

            message.To.Add(MailboxAddress.Parse(sendEmailModel.Email));

            message.Subject = "ZooLine";

            message.Body = new TextPart("plain")
            {
                Text = sendEmailModel.Content

            };

            using (var client = new SmtpClient())
            {
                try
                {
                    // tu maquina no confia en el certificado de google
                    await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                    //todo poner la clave del email
                    //https://kb.synology.com/en-global/SRM/tutorial/How_to_use_Gmail_SMTP_server_to_send_emails_for_SRM
                    //tu toca activar tu cuenta de gmail para poder emiar menseage tambien 
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    //es una cuneta que  funciona ?
                    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);

                    await client.SendAsync(message);
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
