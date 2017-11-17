using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OhSnip.Models.SnippetViewModels;
using OhSnip.Models;
using OhSnip.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace OhSnip.Controllers
{
    public class SnippetController : Controller
    {
        private readonly OhSnipContext _context;

        public SnippetController(OhSnipContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        //// GET: Snippets
        //public async Task<IActionResult> Dashboard()
        //{
        //    return View(await _context.Snippets.ToListAsync());
        //}

        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            List<Snippet> allsnippets = _context.Snippets.ToList();
            ViewBag.allsnippets = allsnippets;

            return View();
        }

        [HttpGet]
        [Route("AddSnippet")]
        public IActionResult ShowAddSnippet()
        {
            DetailViewModel model = new DetailViewModel();
            return View("AddSnippet", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SnippetId,Title,Description,Language,Code,Link,ApplicationUserId")] Snippet snippet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snippet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Dashboard));
            }
            return View(snippet);
        }

        [HttpGet]
        [Route("EditSnippet/{id}")]
        public IActionResult ShowEditSnippet(int id)
        {
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
        public IActionResult DeleteSnippet(int id)
        {
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



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
