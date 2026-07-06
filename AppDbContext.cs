using Microsoft.EntityFrameworkCore;

namespace EFConsoleApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Используем SQL Server LocalDB. База данных создастся автоматически под именем EFCoreLibraryDb.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreLibraryDb;Trusted_Connection=True;");
        }
    }
}
