 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VegetationMonitoring.ViewModels;
using VegetationMonitoring.Services;
using Microsoft.Extensions.Configuration;

namespace VegetationMonitoring.Controllers
{
    public class HomeController : Controller
    {
        // Generate Mail Service thingamajiggy:

        private IMailService _mailService;
        private IConfigurationRoot _config;

        public HomeController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }

















        public IActionResult Index()
        {
            SetViewDataStatement();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Vegetation Monitoring Database:";
            SetViewDataStatement();

            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Email"] = _config["MailSettings:ToAddress"];
            ViewData["MailToEmail"] = string.Format(MailtoLink, _config["MailSettings:ToAddress"], EmailSubject);

            ViewData["Message"] = "Contact Application Development:";
            SetViewDataStatement();

            return View();
        }

        string EmailSubject = "Email from Vegetation Monitoring Application";
        string MailtoLink = @"<a href=""mailto:{0}?Subject={1}"">{0}</a>";

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            ViewData["Email"] = _config["MailSettings:ToAddress"];
            ViewData["MailToEmail"] = string.Format(MailtoLink,_config["MailSettings:ToAddress"], EmailSubject);

            if (model.Email.ToUpper().Contains("AOL.COM"))
            {
                ModelState.AddModelError("Email", "We don't support AOL addresses");
            }

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, $"{EmailSubject} - {model.Name}", model.Body);
                ViewBag.UserMessage = "Message Sent.";
                ModelState.Clear();
            }

            ViewData["Message"] = "Contact Application Development:";
            SetViewDataStatement();

            return View();
        }




        public IActionResult Squirrel()
        {
            ViewData["Message"] = "I like Squirrels.";
            SetViewDataStatement();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private void SetViewDataStatement()
        {
            var names = new List<string> { "stapler", "onion peeler", "garlic press", "tennis racket", "bowling ball", "rolling pin", "walnut opener" };

            Random rand = new Random();
            int index = rand.Next(names.Count);
            var name = names[index];
            names.RemoveAt(index);

            ViewData["TypeOfThing"] = name + ".";
        }

    }
}
