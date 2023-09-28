using FluentValidation;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Validations;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Yazar adı boş olamaz.")
            .Length(3, 100)
            .WithMessage("Yazar adı 3-100 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.Surname)
            .NotEmpty()
            .WithMessage("Yazar soyadı boş olamaz.")
            .Length(3, 100)
            .WithMessage("Yazar soyadı 3-100 karakter aralığından oluşmak zorundadır.");
        RuleFor(c => c.Birthdate)
            .NotNull()
            .WithMessage("Yazar doğum tarihi boş olamaz.");
    }
}