using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OhSnip.Models.SnippetViewModels
{
    public class DetailViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }

        public List<SelectListItem> Languages { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "C", Text = "C"},
            new SelectListItem { Value = "C#", Text = "C#"},
            new SelectListItem { Value = "C++", Text = "C++"},
            new SelectListItem { Value = "CSS", Text = "CSS"},
            new SelectListItem { Value = "Haskell", Text = "Haskell"},
            new SelectListItem { Value = "HTML", Text = "HTML"},
            new SelectListItem { Value = "Java", Text = "Java"},
            new SelectListItem { Value = "JavaScript", Text = "JavaScript"},
            new SelectListItem { Value = "JavaScript React", Text = "JavaScript React"},
            new SelectListItem { Value = "JSON", Text = "JSON"},
            new SelectListItem { Value = "Markdown", Text = "Markdown"},
            new SelectListItem { Value = "PHP", Text = "PHP"},
            new SelectListItem { Value = "Plain Text", Text = "Plain Text"},
            new SelectListItem { Value = "Python", Text = "Python"},
            new SelectListItem { Value = "R", Text = "R"},
            new SelectListItem { Value = "Razor", Text = "Razor"},
            new SelectListItem { Value = "Ruby", Text = "Ruby"},
            new SelectListItem { Value = "SQL", Text = "SQL"},
            new SelectListItem { Value = "Swift", Text = "Swift"},
            new SelectListItem { Value = "Typescript", Text = "Typescript"},
            new SelectListItem { Value = "Visual Basic", Text = "Visual Basic"},
            new SelectListItem { Value = "XML", Text = "XML"},
        };
    }
}
