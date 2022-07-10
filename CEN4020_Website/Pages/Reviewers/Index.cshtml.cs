using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace CEN4020_Website.Pages.Reviewers;
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Reviewer> Reviewer { get; set; }
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Reviewer = _db.Reviewer; //Automatically opens db connection and executes SQL queries
    }

    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("ReviewerID,FirstName,MiddleInitial,LastName,Affiliation,Department,Address,City,State,ZipCode,PhoneNumber,Email");
        //String formatStr = "{0,8:N0},{1,20},{2,13},{3,20},{4,25},{5,50},{6,20},{7,20},{8,8},{9,7:N0},{10,11:N0},{11,25}";
        foreach(var reviewer in _db.Reviewer)
        {
            builder.AppendLine($"{reviewer.ReviewerID},{reviewer.FirstName},{reviewer.MiddleInitial},{reviewer.LastName},{reviewer.Affiliation},{reviewer.Department},{reviewer.Address},{reviewer.City},{reviewer.State},{reviewer.ZipCode},{reviewer.PhoneNumber},{reviewer.EmailAddress}");

            //builder.AppendFormat(formatStr, reviewer.ReviewerID, reviewer.FirstName, reviewer.MiddleInitial, reviewer.LastName, reviewer.Affiliation, reviewer.Department, reviewer.Address, reviewer.City, reviewer.State, reviewer.ZipCode, reviewer.PhoneNumber, reviewer.EmailAddress);
            //builder.AppendLine();
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Reviewers_Report.csv");
    }
}
