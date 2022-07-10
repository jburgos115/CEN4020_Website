using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace CEN4020_Website.Pages.ListOfAuth;
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Author> ListOfAuth { get; set; }
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        ListOfAuth = _db.Author; //Automatically opens db connection and executes SQL queries
    }

    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("AuthorID,FirstName,MiddleInitial,LastName,Affiliation,Department,Address,City,State,ZipCode,PhoneNumber,Email");
        //String formatStr = "{0,8:N0},{1,20},{2,13},{3,20},{4,25},{5,50},{6,20},{7,20},{8,8},{9,7:N0},{10,11:N0},{11,25}";
        foreach(var author in _db.Author)
        {
            builder.AppendLine($"{author.AuthorID},{author.FirstName},{author.MiddleInitial},{author.LastName},{author.Affiliation},{author.Department},{author.Address},{author.City},{author.State},{author.ZipCode},{author.PhoneNumber},{author.EmailAddress}");

            //builder.AppendFormat(formatStr, author.AuthorID, author.FirstName, author.MiddleInitial, author.LastName, author.Affiliation, author.Department, author.Address, author.City, author.State, author.ZipCode, author.PhoneNumber, author.EmailAddress);
            //builder.AppendLine();
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Authors_Report.csv");
    }
}
