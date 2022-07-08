using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.ListOfAuth
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Author Author { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Author = _db.Author.Find(id);

        }

        public async Task<IActionResult> OnPost(Model.Author author)
        {
            _db.Author.Update(author);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
