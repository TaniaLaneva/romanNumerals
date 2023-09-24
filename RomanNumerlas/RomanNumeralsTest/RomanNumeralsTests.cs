using FluentAssertions;

namespace RomanNumeralsTest;

public class UnitTest1
{
    private readonly RomanNumerals.RomanNumerals _romanNumerals = new();

    [Theory]
    [MemberData(nameof(ValidRomanNumerals))]
    public void ConvertToArabic_ValidStringInput_ReturnCorrectArabic(string romanNumber, long arabicNumber)
    {
        var number = _romanNumerals.ConvertToArabic(romanNumber);

        number.Should().Be(arabicNumber);
    }

    public static IEnumerable<object[]> ValidRomanNumerals => new List<object[]>
    {
        new object[] { "I", 1 },
        new object[] { "II", 2 },
        new object[] { "III", 3 },
        new object[] { "IV", 4 },
        new object[] { "V", 5 },
        new object[] { "VI", 6 },
        new object[] { "VII", 7 },
        new object[] { "VIII", 8 },
        new object[] { "IX", 9 },
        new object[] { "LXXVIII", 78 },
        new object[] { "LXXXIX", 89 },
        new object[] { "XCVI", 96 },
        new object[] { "XCIX", 99 },
        new object[] { "C", 100 },
        new object[] { "DCCC", 800 },
        new object[] { "CM", 900 },
        new object[]{string.Empty, 0}
    };
}