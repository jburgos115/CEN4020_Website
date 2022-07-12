using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Papers
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Paper Paper { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Model.Paper paper)
        {
            paper.AuthorID = 4; //input authorID from cookie
            if (ModelState.IsValid) //if db error occurs, then reload the page
            {
                await _db.Paper.AddAsync(paper);
                await _db.SaveChangesAsync();
                TempData["success"] = "New Paper Created Successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
