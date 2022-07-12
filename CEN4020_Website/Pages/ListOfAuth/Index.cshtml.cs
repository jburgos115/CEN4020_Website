using CEN4020_Website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;


/*
 *  INDEX FOR AUTHORS
 */

namespace CEN4020_Website.Pages.ListOfAuth;

//Only admins can view this page
[Authorize(Policy = "AdminCredentialsRequired")]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Author> ListOfAuth { get; set; } //Authors object

    //Database context
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        ListOfAuth = _db.Author; //Automatically opens db connection and executes SQL queries
    }
    
    //Generate report button functionality. Allows the user to download a .csv file containing all author records
    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("AuthorID,FirstName,MiddleInitial,LastName,Affiliation,Department,Address,City,State,ZipCode,PhoneNumber,Email");
        foreach(var author in _db.Author)
        {
            builder.AppendLine($"{author.AuthorID},{author.FirstName},{author.MiddleInitial},{author.LastName},{author.Affiliation},{author.Department},{author.Address},{author.City},{author.State},{author.ZipCode},{author.PhoneNumber},{author.EmailAddress}");
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Authors_Report.csv");
    }
}

