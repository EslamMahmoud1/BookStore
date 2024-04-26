using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BookStore.Data
{
    public class BookStoreContext : IdentityDbContext<BookStoreUser>
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(builder);
		}
		public DbSet<Book> Books { get; set; }

    }
}
