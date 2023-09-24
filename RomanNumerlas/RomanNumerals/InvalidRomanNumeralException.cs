using System.Runtime.Serialization;

namespace RomanNumerals;

[Serializable]
public class InvalidRomanNumeralException : Exception
{
    public InvalidRomanNumeralException(string invalidRomanNumeral) : base(
        $"{invalidRomanNumeral} is invalid roman numeral")
    {
    }
    
    protected InvalidRomanNumeralException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}