using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.ListOfAuth
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Author Author { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Author = _db.Author.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Author author)
        {
            var authorFromDb = _db.Author.Find(author.AuthorID);
            if(authorFromDb != null)
            {
                _db.Author.Remove(authorFromDb);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            
            return Page();

        }
    }
}
