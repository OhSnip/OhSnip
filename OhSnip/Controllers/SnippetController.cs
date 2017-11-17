using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OhSnip.Models;
using OhSnip.Models.SnippetViewModels;

namespace OhSnip.Controllers
{
    public class SnippetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        [Route("AddSnippet")]
        public IActionResult ShowAddSnippet()
        {
            DetailViewModel model = new DetailViewModel();
            return View("AddSnippet", model);
        }

        [HttpGet]
        [Route("EditSnippet")]
        public IActionResult ShowEditSnippet()
        {
            DetailViewModel model = new DetailViewModel();
            return View("EditSnippet", model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
