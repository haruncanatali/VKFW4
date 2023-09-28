using FluentValidation;
using LibraryApp.Entities.Domain;

namespace LibraryApp.Business.Validations;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Tür adı boş olamaz.")
            .Length(3, 100)
            .WithMessage("Tür adı 3-100 karakter aralığından oluşmak zorundadır.");
    }
}