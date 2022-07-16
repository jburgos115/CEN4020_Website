using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;


/*
 *  DELETE FOR REVIEWS
 */

namespace CEN4020_Website.Pages.Reviews
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Review Review { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //Retrieves data from database for a specific id and populates respective UI assets
        public void OnGet(int id)
        {
            Review = _db.Review.Find(id);
        }

        //Controller to delete record from database
        public async Task<IActionResult> OnPost(Model.Review review)
        {
            var reviewerFromDb = _db.Review.Find(review.ReviewID);
            try
            {
                if (reviewerFromDb != null)
                {
                    _db.Review.AddAsync(reviewerFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "New Review Created Successfully";
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Sorry, we are unable to process your request at this time. Please try again later.";
            }
            return RedirectToPage("Index");

        }
    }
}
