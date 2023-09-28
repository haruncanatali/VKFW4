using FluentValidation;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Validations;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Kitap adı boş olamaz.")
            .Length(1, 150)
            .WithMessage("Kitap adı 1-150 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.ISBN)
            .NotEmpty()
            .WithMessage("ISBN boş olamaz.")
            .Length(1, 30)
            .WithMessage("ISBN 1-150 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.PageCount)
            .NotNull()
            .WithMessage("Sayfa sayısı boş olamaz.");
        RuleFor(c => c.BookStatus)
            .NotNull()
            .WithMessage("Kitap durumu boş olamaz.");
        RuleFor(c => c.GenreId)
            .NotEmpty()
            .WithMessage("Kitap türü boş olamaz.");
        RuleFor(c => c.AuthorId)
            .NotEmpty()
            .WithMessage("Kitap yazarı boş olamaz.");
    }
}