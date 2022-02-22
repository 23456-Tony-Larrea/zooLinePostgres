using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooLine.Models;

namespace ZooLine.Utilities
{
   public interface IMailHandler
    {
        /// <summary>
        /// Envia Email desde el servidor 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SendEmailAsync(SendEmailModel model);
    }
}
