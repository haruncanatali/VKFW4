using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Common.Concrete;

public class ApplicationContext : DbContext,IApplicationContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}