 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VegetationMonitoring.ViewModels;
using VegetationMonitoring.Services;

namespace VegetationMonitoring.Controllers
{
    public class HomeController : Controller
    {
        // Generate Mail Service thingamajiggy:

        private IMailService _mailService;
        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
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
            ViewData["Message"] = "Contact Application Development:";
            SetViewDataStatement();

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {

            _mailService.SendMail("support@cloca.com", model.Email, $"Email from Vegetation Monitoring Application - {model.Name}", model.Body);


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
