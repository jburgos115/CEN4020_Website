using CEN4020_Website.Model;
using Microsoft.EntityFrameworkCore;


namespace CEN4020_Website.Data;
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	//List of Model objects
	public DbSet<Author> Author { get; set; }
	public DbSet<Reviewer> Reviewer { get; set; }
	public DbSet<Paper> Paper { get; set; }
	public DbSet<Review> Review { get; set; }
}
