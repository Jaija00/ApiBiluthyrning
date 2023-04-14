using BiluthyrningApi.Models;
using BiluthyrningApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BiluthyrningApi.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Car> Cars { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<AvailableCarsViewModel> AvailableCarsViewModel { get; set; }
	}
}
