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
            review.AppropriatenessOfTopic = 0.00m;
            review.TimelinessOfTopic = 0.00m;
            review.SupportiveEvidence = 0.00m;
            review.TechnicalQuality = 0.00m;
            review.ScopeOfCoverage = 0.00m;
            review.CitationOfPreviousWork = 0.00m;
            review.Originality = 0.00m;
            review.ContentComments = "";
            review.OrganizationOfPaper = 0.00m;
            review.ClarityOfMainMessage = 0.00m;
            review.Mechanics = 0.00m;
            review.WrittenDocumentComments = "";
            review.SuitabilityForPresentation = 0.00m;
            review.PotentialInterestInTopic = 0.00m;
            review.PotentialForOralPresentationComments = "";
            review.OverallRating = 0.00m;
            review.OverallRatingComments = "";
            review.ComfortLevelTopic = 0.00m;
            review.ComfortLevelAcceptability = 0.00m;
            review.Complete = false;
            //if (ModelState.IsValid) //if db error occurs, then reload the page
            //{
                await _db.Review.AddAsync(review);
                await _db.SaveChangesAsync();
                TempData["success"] = "New Review Created Successfully";
                return RedirectToPage("Index");
            //}

            //return Page();
        }
    }
}
