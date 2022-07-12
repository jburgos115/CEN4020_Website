using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Papers
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Paper Paper { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Paper = _db.Paper.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Paper paper)
        {
            if (ModelState.IsValid)
            {
                _db.Paper.Update(paper);
                await _db.SaveChangesAsync();
                TempData["success"] = "Paper Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
