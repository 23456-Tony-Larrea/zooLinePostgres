using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace prueba
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
  
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
    }
}
