using CEN4020_Website.Pages.PaperReview;
using Microsoft.EntityFrameworkCore;

namespace CEN4020_Website.Data;

public class Dbctxt: DbContext
{
    public Dbctxt(DbContextOptions<Dbctxt> options): base(options)
    {
        
    }

    public DbSet<Review> Review { get; set; }
}
