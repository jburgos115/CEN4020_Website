using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEN4020_Website.Data;
using CEN4020_Website.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Model.Author Author { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _db.Author.AddAsync(Author);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
