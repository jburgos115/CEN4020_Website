using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace CEN4020_Website.Pages.Reviews;
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Review> Review { get; set; }
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Review = _db.Review; //Automatically opens db connection and executes SQL queries
    }

    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("ReviewID,PaperID,ReviewerID,AppropriatenessOfTopic,TimelinessOfTopic,SupportiveEvidence,TechnicalQuality," +
                                $"ScopeOfCoverage,CitationOfPreviousWork,Originality,ContentComments,OrganizationOfPaper,ClarityOfMainMessage,Mechanics,WrittenDocumentComments,SuitabilityForPresentation," +
                                $"PotentialInterestInTopic,PotentialForOralPresentationComments,OverallRating,OverallRatingComments,ComfortLevelTopic,ComfortLevelAcceptability,Complete");
        //String formatStr = "{0,8:N0},{1,20},{2,13},{3,20},{4,25},{5,50},{6,20},{7,20},{8,8},{9,7:N0},{10,11:N0},{11,25}";
        foreach(var review in _db.Review)
        {
            builder.AppendLine($"{review.ReviewID},{review.PaperID},{review.ReviewerID},{review.AppropriatenessOfTopic},{review.TimelinessOfTopic},{review.SupportiveEvidence},{review.TechnicalQuality}," +
                                $"{review.ScopeOfCoverage},{review.CitationOfPreviousWork},{review.Originality},{review.ContentComments},{review.OrganizationOfPaper},{review.ClarityOfMainMessage},{review.Mechanics},{review.WrittenDocumentComments},{review.SuitabilityForPresentation}," +
                                $"{review.PotentialInterestInTopic},{review.PotentialForOralPresentationComments},{review.OverallRating},{review.OverallRatingComments},{review.ComfortLevelTopic},{review.ComfortLevelAcceptability},{review.Complete}");

            //builder.AppendFormat(formatStr, review.ReviewID, review.FirstName, review.MiddleInitial, review.LastName, review.Affiliation, review.Department, review.Address, review.City, review.State, review.ZipCode, review.PhoneNumber, review.EmailAddress);
            //builder.AppendLine();
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Reviews_Report.csv");
    }
}
