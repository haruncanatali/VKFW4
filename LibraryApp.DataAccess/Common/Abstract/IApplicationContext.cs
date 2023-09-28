using LibraryApp.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Common.Abstract;

public interface IApplicationContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}