using Microsoft.EntityFrameworkCore;
namespace Bylines.LandingPage.Data;
public class WaitlistDbContext : DbContext
{
	public WaitlistDbContext(DbContextOptions<WaitlistDbContext> options) : base(options) { }
	public DbSet<WaitlistSubmissionData> WaitlistSubmissions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		//modelBuilder.HasServiceTier("Basic");
	}
}