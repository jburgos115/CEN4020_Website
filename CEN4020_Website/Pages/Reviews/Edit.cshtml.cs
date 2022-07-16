using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;


/*
 *  EDIT FOR REVIEWS
 */

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

        //Retrieves data from database for a specific id and populates respective UI assets
        public void OnGet(int id)
        {
            Review = _db.Review.Find(id);
        }

        //Controller to save changes
        public async Task<IActionResult> OnPost(Model.Review review)
        {
            try
            {
                _db.Review.Update(review);
                await _db.SaveChangesAsync();
                TempData["success"] = "Review Edited Successfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Sorry, we are unable to process your request at this time. Please try again later.";
            }
            return RedirectToPage("Index");
        }
    }
}
