using HB.WebAPITokenIdentiyBook.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HB.WebAPITokenIdentiyBook.Context
{
	public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
	{
		
		public DbSet<Book> Books { get; set; }
		public DbSet<UserFavBooks> UserFavBooks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserFavBooks>().HasKey(x => new { x.BookId,x.AppUserId});
			modelBuilder.Entity<UserFavBooks>().HasOne(x => x.AppUser).WithMany(x => x.UserFavBooks).HasForeignKey(x => x.AppUserId);
			modelBuilder.Entity<UserFavBooks>().HasOne(x=>x.Books).WithMany(x=>x.UserFavBooks).HasForeignKey(x => x.BookId);
			base.OnModelCreating(modelBuilder);
		}
	}
}
