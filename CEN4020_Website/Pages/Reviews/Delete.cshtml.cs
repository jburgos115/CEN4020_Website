using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Papers
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Paper Paper { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Paper = _db.Paper.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Paper paper)
        {
            var reviewerFromDb = _db.Paper.Find(paper.PaperID);
            if(reviewerFromDb != null)
            {
                _db.Paper.Remove(reviewerFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Paper Deleted Successfully";
                return RedirectToPage("Index");
            }
            
            return Page();

        }
    }
}
