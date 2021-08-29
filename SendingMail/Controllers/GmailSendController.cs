using SendingMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SendingMail.Controllers
{
    public class GmailSendController : Controller
    {
        // GET: GmailSend
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailClass email)
        {
            HttpClient hc = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44323/api/Email")
            };
            var consumeWebApi = hc.PostAsJsonAsync<EmailClass>("Email", email);
            consumeWebApi.Wait();
            var sendmail = consumeWebApi.Result;
            if (sendmail.IsSuccessStatusCode)
            {
                ViewBag.message = "Mail has been sent to " + email.SendTo.ToString();

            }
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(EmailClass emailClass)
        {
            
            try
            {
                string sendto = emailClass.SendTo;
                string[] multiple = sendto.Split(',');
                int count = 0;
                foreach(string multi in multiple)
                {
                    count++;
                }
                EmailSentInfoEntities1 entity = new EmailSentInfoEntities1();
                MailSentDetail mailSentDetail = new MailSentDetail
                {
                    No_Of_Addresses = count,
                    Date = DateTime.Now,

                    MailSent = true.ToString()
                };

                entity.MailSentDetails.Add(mailSentDetail);
                entity.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}