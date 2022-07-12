using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Reviews
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Review Review { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Review = _db.Review.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Review review)
        {
            if (ModelState.IsValid)
            {
                _db.Review.Update(review);
                await _db.SaveChangesAsync();
                TempData["success"] = "Review Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
