using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.Reviews
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Review Review { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Model.Review review)
        {
            //review.AuthorID = 4; //input authorID from cookie
            if (ModelState.IsValid) //if db error occurs, then reload the page
            {
                await _db.Review.AddAsync(review);
                await _db.SaveChangesAsync();
                TempData["success"] = "New Review Created Successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
