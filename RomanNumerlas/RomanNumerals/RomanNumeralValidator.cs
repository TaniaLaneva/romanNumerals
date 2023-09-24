using FluentValidation;

namespace RomanNumerals;

public class RomanNumeralValidator : AbstractValidator<string>
{
    private const string ValidRomanNumeralRegex = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

    public RomanNumeralValidator()
    {
        RuleFor(s => s).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Length(1, 50)
            .Matches(ValidRomanNumeralRegex);
    }
}