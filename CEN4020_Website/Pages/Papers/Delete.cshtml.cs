using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


/*
 *  DELETE FOR PAPERS
 */

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

        //Retrieves data from database for a specific id and populates respective UI assets
        public void OnGet(int id)
        {
            Paper = _db.Paper.Find(id);
        }

        //Controller to delete record from database
        public async Task<IActionResult> OnPost(Model.Paper paper)
        {
            var reviewerFromDb = _db.Paper.Find(paper.PaperID);
            try
            {
                if (reviewerFromDb != null)
                {
                    _db.Paper.Remove(reviewerFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Paper Deleted Successfully";
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
