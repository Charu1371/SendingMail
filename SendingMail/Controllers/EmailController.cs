using SendingMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Data.Entity;

namespace SendingMail.Controllers
{
    public class EmailController : ApiController
    {
        public IHttpActionResult Sendmail(EmailClass email)
        {
            string subject = email.Subject;
            string body = email.Body;
            string SendTo = email.SendTo;
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("charu.sahrawat@gmail.com")
            };
            mailMessage.To.Add(SendTo);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = false;
            
            string[] multi = SendTo.Split(',');
            
            foreach (string multiemail in multi)
            {
                mailMessage.To.Add(new MailAddress(multiemail));
                   
            }
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,

                Credentials = new System.Net.NetworkCredential("charu.sahrawat@gmail.com", "charu.s1371"),
                EnableSsl = true
            };

            smtp.Send(mailMessage);

          
            return Ok();



        }

    }
}
