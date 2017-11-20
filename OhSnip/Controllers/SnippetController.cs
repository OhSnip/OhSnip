using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

using OhSnip.Models.SnippetViewModels;
using OhSnip.Models;
using OhSnip.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace OhSnip.Controllers
{
    public class SnippetController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly OhSnipContext _context;

        public SnippetController(OhSnipContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "You must login before viewing that page!";
                return RedirectToAction("Login", "Account");
            }

            List<Snippet> allsnippets = _context.Snippets.ToList();
            ViewBag.allsnippets = allsnippets;

            return View();
        }

        [HttpGet]
        [Route("AddSnippet")]
        public async Task<IActionResult> ShowAddSnippet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "You must login before viewing that page!";
                return RedirectToAction("Login", "Account");
            }

            DetailViewModel model = new DetailViewModel();
            return View("AddSnippet", model);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(DetailViewModel snip)
        {
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                Snippet newSnip = new Snippet
                {
                    Title = snip.Title,
                    Description = snip.Description,
                    Language = snip.Language,
                    Code = snip.Code,
                    Link = snip.Link,
                    ApplicationUserId = user.Id,
                };
                _context.Snippets.Add(newSnip);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");

            }
            return View("AddSnippet", snip);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("SnippetId,Title,Description,Language,Code,Link,ApplicationUserId")] Snippet snippet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(snippet);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Dashboard));
        //    }
        //    return View("AddSnippet", snippet);
        //}
                   

    [HttpGet]
        [Route("EditSnippet/{id}")]
        public async Task<IActionResult> ShowEditSnippet(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "You must login before viewing that page!";
                return RedirectToAction("Login", "Account");
            }

            DetailViewModel model = new DetailViewModel();
            ViewBag.snippettoedit = _context.Snippets.Where(snip => snip.SnippetId == id);
            return View("EditSnippet", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("SnippetId,Title,Description,Language,Code,Link,ApplicationUserId")] Snippet snippet)
        {
            if (ModelState.IsValid)
            {
                _context.Snippets.Update(snippet);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dashboard));
            }
            return View(snippet);
        }

        [HttpGet]
        [Route("DeleteSnippet/{id}")]
        public async Task<IActionResult> DeleteSnippet(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["ErrorMessage"] = "You must login before viewing that page!";
                return RedirectToAction("Login", "Account");
            }

            ViewBag.sniptodelete = _context.Snippets.Where(snip => snip.SnippetId == id);
            return View();
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Snippet snipdelete = _context.Snippets.Where(snip => snip.SnippetId == id).SingleOrDefault();
            _context.Snippets.Remove(snipdelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");

        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search(string searchString)
        {
            ViewBag.searchsnippets = _context
                .Snippets
                .Where(item => item.Code.Contains(searchString)
                    || item.Description.Contains(searchString)
                    || item.Title.Contains(searchString)
                    );
            return View("Dashboard");
        }
        


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
