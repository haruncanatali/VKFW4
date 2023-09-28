using FluentValidation;

namespace LibraryApp.Business.Tools;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object instance)
    {
        if (validator == null || instance == null) return;

        var context = new ValidationContext<object>(instance);
        var result = validator.Validate(context);

        if (!result.IsValid)
        {
            var exceptions = new ValidationException(result.Errors);
            throw new Exception(exceptions.Message);
        }
    }
}