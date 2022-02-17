using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace ZooLine.Controllers
{
    public class Mail
    { 
        public Mail(string[] args)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("hola esto es un test bienvenido a zooline", "avs.larrea@yavirac.edu.ec"));

            message.To.Add(MailboxAddress.Parse("avs.larrea@yavirac.edu.ec"));

            message.Subject = "ZooLine";

            message.Body = new TextPart("test")
            {
                Text = @"Yes,
                hola ! 
                 quiero darte la bienvenida a ZooLine "

            };

            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Send(message);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
