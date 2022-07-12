using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


/*
 *  EDIT FOR REVIEWERS
 */

namespace CEN4020_Website.Pages.Reviewers
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Reviewer Reviewer { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //Retrieves data from database for a specific id and populates respective UI assets
        public void OnGet(int id)
        {
            Reviewer = _db.Reviewer.Find(id);
        }

        //Controller to save changes
        public async Task<IActionResult> OnPost(Model.Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                _db.Reviewer.Update(reviewer);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reviewer Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
