using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myRegistrationSite.Models;
using Newtonsoft.Json;

namespace myRegistrationSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private string GetAttendeesDirPath()
        {
            var attendeesDirPath = Path.Combine(Server.MapPath("~/App_Data/"), "Attendees");
            if (Directory.Exists(attendeesDirPath) == false) Directory.CreateDirectory(attendeesDirPath);
            return attendeesDirPath;
        }

        public ActionResult Index()
        {
            var attendeesDirPath = GetAttendeesDirPath();
            var attendees = Directory.GetFiles(attendeesDirPath, "*.json")
                .Select(path => System.IO.File.ReadAllText(path))
                .Select(json => JsonConvert.DeserializeObject<Attendee>(json))
                .OrderBy(attendee => attendee.CreateAt);

            return View(attendees);
        }

        [HttpPost]
        public ActionResult ClearAll()
        {
            var attendeesDirPath = GetAttendeesDirPath();
            Directory.GetFiles(attendeesDirPath, "*.json")
                .ToList()
                .ForEach(path => System.IO.File.Delete(path));

            return RedirectToAction("Index");
        }
    }
}