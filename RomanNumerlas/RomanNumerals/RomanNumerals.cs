using System.Collections.ObjectModel;

namespace RomanNumerals;

public interface IRomanNumerals
{
    long ConvertToArabic(string validRomanNumeral);
}

public class RomanNumerals : IRomanNumerals
{
    public long ConvertToArabic(string validRomanNumeral)
    {
        long arabicNumeral = 0;
        var previousRomanSymbolValue = 0;

        foreach (var romanSymbolValue in validRomanNumeral.Select(symbol => ArabicMap[symbol]))
        {
            arabicNumeral += romanSymbolValue;
            if (romanSymbolValue > previousRomanSymbolValue) arabicNumeral -= previousRomanSymbolValue * 2;

            previousRomanSymbolValue = romanSymbolValue;
        }

        return arabicNumeral;
    }

    private static readonly IReadOnlyDictionary<char, int> ArabicMap = new ReadOnlyDictionary<char, int>(
        new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        });
}