using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.PaperReview
{
    [BindProperties]
    public class DeleteReviewModel : PageModel
    {
        private readonly Dbctxt _dbctxt;

        public Review Review { get; set; }
        public DeleteReviewModel(Dbctxt dbctxt)
        {
            _dbctxt = dbctxt;
        }

        public void OnGet(int reviewid)
        {
            Review = _dbctxt.Review.Find(reviewid);
            //Review = _dbctxt.Review.FirstOrDefault(u=>u.PaperID== paperid);
            //Review = _dbctxt.Review.SingleOrDefault(u => u.PaperID == paperid);
            //Review = _dbctxt.Review.Where(u => u.PaperID == paperid).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            
            
                var reviewFromDb = _dbctxt.Review.Find(Review.ReviewID);
                if (reviewFromDb != null)
                {
                    _dbctxt.Review.Remove(reviewFromDb);
                    await _dbctxt.SaveChangesAsync();
                    return RedirectToPage("Index");
                 }

                
            
            return Page();
        }
    }
}
