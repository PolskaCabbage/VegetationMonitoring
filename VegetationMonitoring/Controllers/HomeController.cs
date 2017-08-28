using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VegetationMonitoring.Controllers
{
    public class HomeController : Controller
    {
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
