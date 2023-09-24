using FluentAssertions;
using RomanNumerals;

namespace RomanNumeralsTest;

public class ValidRomanNumeralStringTests
{
    private readonly RomanNumeralValidator _validator = new();

    [Theory]
    [MemberData(nameof(InvalidRomanNumerals))]
    public void ValidateRomanNumeralString_InvalidRomanNumeral_InvalidResult(string invalidRomanNumeral)
    {
        var validationResult = _validator.Validate(invalidRomanNumeral);

        validationResult.IsValid.Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(ValidRomanNumerals))]
    public void ValidateRomanNumeralString_ValidRomanNumeral_ValidResult(string validRomanNumeral)
    {
        var validationResult = _validator.Validate(validRomanNumeral);

        validationResult.IsValid.Should().BeTrue();
    }

    public static IEnumerable<object[]> InvalidRomanNumerals => new List<object[]>
    {
        new object[] { "IIII" },
        new object[] { "VIIII" },
        new object[] { "VV" },
        new object[] { "VVV" },
        new object[] { "XXXX" },
        new object[] { "LL" },
        new object[] { "XCIIX" },
        new object[] { "I am a text" },
        new object[] { @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$" },
        new object[] { string.Empty }
    };

    public static IEnumerable<object[]> ValidRomanNumerals => new List<object[]>
    {
        new object[] { "I" },
        new object[] { "II" },
        new object[] { "III" },
        new object[] { "IV" },
        new object[] { "V" },
        new object[] { "VI" },
        new object[] { "VII" },
        new object[] { "VIII" },
        new object[] { "IX" },
        new object[] { "LXXVIII" },
        new object[] { "LXXXIX" },
        new object[] { "XCVI" },
        new object[] { "XCIX" },
        new object[] { "C" },
        new object[] { "DCCC" },
        new object[] { "CM" }
    };
}