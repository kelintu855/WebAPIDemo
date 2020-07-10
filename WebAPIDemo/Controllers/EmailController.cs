using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace WebAPIDemo.Controllers
{
    public class EmailController : ApiController
    {
        [HttpPost]
        [Route("api/email/send-email")]
        public async Task SendEmail()
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("Kelin Tu <kelin.tu@logicsolutions.com>"));
            message.From = new MailAddress("Kelin Tu <kelintu855@gmail.com>");
            //message.Bcc.Add(new MailAddress(""));
            message.Subject = "Test Email";
            message.Body = "This is a test email";
            message.IsBodyHtml = false;
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
                await Task.FromResult(0);
            }
        }

        
    }
}
