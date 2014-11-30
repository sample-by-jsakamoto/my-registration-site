using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using myRegistrationSite.Models;
using Newtonsoft.Json;

namespace myRegistrationSite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Attendee attendee)
        {
            attendee.CreateAt = DateTime.UtcNow;
            var json = JsonConvert.SerializeObject(attendee);

            var attendeesDirPath = Path.Combine(Server.MapPath("~/App_Data/"), "Attendees");
            if (Directory.Exists(attendeesDirPath) == false) Directory.CreateDirectory(attendeesDirPath);
            var attendeeFilePath = Path.Combine(attendeesDirPath, Guid.NewGuid().ToString() + ".json");
            System.IO.File.WriteAllText(attendeeFilePath, json);

            var smtpConfig = AppSettings.Smtp.Network;
            if (smtpConfig != null)
            {
                var smtpClient = JsonConvert.DeserializeObject<SmtpClient>(AppSettings.Smtp.Network);
                smtpClient.Credentials = JsonConvert.DeserializeObject<NetworkCredential>(AppSettings.Smtp.Credential);
                using (smtpClient)
                {
                    smtpClient.Send(
                        from: AppSettings.Smtp.From,
                        recipients: attendee.Email,
                        subject: "IT勉強会 参加申し込みサイト - 参加登録完了のお知らせ",
                        body: "参加登録が完了しました。\n参加申し込みありがとうございました。"
                    );
                }
            }

            return RedirectToAction("Complete");
        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}