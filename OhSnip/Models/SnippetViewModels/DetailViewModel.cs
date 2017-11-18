using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OhSnip.Models.SnippetViewModels
{
    public class DetailViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 2)]
        public string Code { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Source")]
        public string Link { get; set; }

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
