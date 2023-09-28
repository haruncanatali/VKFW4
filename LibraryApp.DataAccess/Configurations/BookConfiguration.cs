using LibraryApp.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(c => c.Name).IsRequired().HasMaxLength(150);
        builder.Property(c => c.ISBN).IsRequired().HasMaxLength(30);
        builder.Property(c => c.PageCount).IsRequired().HasDefaultValue(0);
        builder.Property(c => c.BookStatus).IsRequired().HasDefaultValue(2);
        builder.Property(c => c.GenreId).IsRequired();
        builder.Property(c => c.AuthorId).IsRequired();
    }
}