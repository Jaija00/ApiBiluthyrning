using BiluthyrningApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BiluthyrningApi.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Car> Cars { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Booking> Bookings { get; set; }
	}
}
