using Microsoft.EntityFrameworkCore;
namespace Bylines.LandingPage.Data;
public class WaitlistDbContext : DbContext
{
	public WaitlistDbContext(DbContextOptions<WaitlistDbContext> options) : base(options) { }
	public DbSet<WaitlistForm> WaitlistSubmissions { get; set; }
}