using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooLine.Models;

namespace ZooLine.Services
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(MailRequest request);

    }
}
