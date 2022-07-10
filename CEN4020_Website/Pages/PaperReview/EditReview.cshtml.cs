using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.PaperReview
{
    [BindProperties]
    public class EditReviewModel : PageModel
    {
        private readonly Dbctxt _dbctxt;

        public Review Review { get; set; }
        public EditReviewModel(Dbctxt dbctxt)
        {
            _dbctxt = dbctxt;
        }

        public void OnGet(int reviewid)
        {
            //Review = _dbctxt.Review.Find(reviewid);
            Review = _dbctxt.Review.FirstOrDefault(u=>u.ReviewID== reviewid);
            //Review = _dbctxt.Review.SingleOrDefault(u => u.PaperID == paperid);
            //Review = _dbctxt.Review.Where(u => u.PaperID == paperid).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            _dbctxt.Review.Update(Review);
            await _dbctxt.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
