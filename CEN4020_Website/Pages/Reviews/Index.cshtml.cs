using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;


/*
 *  INDEX FOR REVIEWS
 */

namespace CEN4020_Website.Pages.Reviews;

//Main user view for Reviewers
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public IEnumerable<Model.Review> Review { get; set; } //Review object

    //Database context
    public IndexModel(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
    {
        _db = db;
        this._webHostEnvironment = webHostEnvironment;
    }

    public void OnGet()
    {
        Review = _db.Review; //Automatically opens db connection and executes SQL queries
    }

    //Generate report button functionality. Allows the user to download a .csv file containing all Review records
    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("ReviewID,PaperID,ReviewerID,AppropriatenessOfTopic,TimelinessOfTopic,SupportiveEvidence,TechnicalQuality," +
                                $"ScopeOfCoverage,CitationOfPreviousWork,Originality,ContentComments,OrganizationOfPaper,ClarityOfMainMessage,Mechanics,WrittenDocumentComments,SuitabilityForPresentation," +
                                $"PotentialInterestInTopic,PotentialForOralPresentationComments,OverallRating,OverallRatingComments,ComfortLevelTopic,ComfortLevelAcceptability,Complete");
        foreach(var review in _db.Review)
        {
            builder.AppendLine($"{review.ReviewID},{review.PaperID},{review.ReviewerID},{review.AppropriatenessOfTopic},{review.TimelinessOfTopic},{review.SupportiveEvidence},{review.TechnicalQuality}," +
                                $"{review.ScopeOfCoverage},{review.CitationOfPreviousWork},{review.Originality},{review.ContentComments},{review.OrganizationOfPaper},{review.ClarityOfMainMessage},{review.Mechanics},{review.WrittenDocumentComments},{review.SuitabilityForPresentation}," +
                                $"{review.PotentialInterestInTopic},{review.PotentialForOralPresentationComments},{review.OverallRating},{review.OverallRatingComments},{review.ComfortLevelTopic},{review.ComfortLevelAcceptability},{review.Complete}");
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Reviews_Report.csv");
    }

    //Controller for Download pdf file
    public FileResult OnGetDownload(string filename)
    {
        string path = Path.Combine(this._webHostEnvironment.WebRootPath, "Uploads/") + filename;
        byte[] buffer = System.IO.File.ReadAllBytes(path);
        return File(buffer, "application/octet-stream", filename);
    }
}
