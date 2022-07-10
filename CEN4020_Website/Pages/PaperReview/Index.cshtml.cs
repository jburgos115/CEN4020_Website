using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.PaperReview;

public class IndexModel : PageModel
{
    private readonly Dbctxt _db;
    public IEnumerable<Review> Reviews { get; set; }
    public IndexModel(Dbctxt db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Reviews = _db.Review;
    }
}
