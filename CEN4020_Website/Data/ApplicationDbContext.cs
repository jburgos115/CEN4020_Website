using Microsoft.EntityFrameworkCore;
using CEN4020_Website.Model;

namespace CEN4020_Website.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Author> Author { get; set; }
	}
}
