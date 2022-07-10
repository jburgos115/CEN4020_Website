using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.PaperReview
{
    [BindProperties]
    public class AddReviewModel : PageModel
    {
        private readonly Dbctxt _dbctxt;

        public Review Review { get; set; }
        public AddReviewModel(Dbctxt dbctxt)
        {
            _dbctxt = dbctxt;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(Review review)
        {
            //if (ModelState.IsValid)
            //{
                await _dbctxt.Review.AddAsync(review);
                await _dbctxt.SaveChangesAsync();
                return RedirectToPage("Index");
            //}
            //return Page();
        }
    }
}
