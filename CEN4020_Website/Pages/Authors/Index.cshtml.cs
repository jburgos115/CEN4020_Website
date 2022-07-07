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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Model.Author> Authors { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Authors = _db.Author;
        }
    }
}
