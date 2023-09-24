using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using RomanNumerals;

namespace RomanNumeralsTest;

public class ControllerTests
{
    private readonly ILogger<RomanNumeralController> _loggerMock = Substitute.For<ILogger<RomanNumeralController>>();
    private readonly IRomanNumerals _romanNumeralsMock = Substitute.For<IRomanNumerals>();
    private readonly IValidator<string> _validatorMock = Substitute.For<IValidator<string>>();

    private readonly RomanNumeralController _controller;

    public ControllerTests()
    {
        _controller = new RomanNumeralController(_loggerMock, _romanNumeralsMock, _validatorMock);
        _validatorMock.Validate(Arg.Is<string>(a => a.Equals("IX"))).Returns(new ValidationResult());
    }

    [Fact]
    public void ConvertRomanNumeralToArabic_InvalidInput_ReturnBadResult()
    {
        _validatorMock.Validate(Arg.Is<string>(a => a.Equals("IIII")))
            .Returns(new ValidationResult { Errors = new List<ValidationFailure> { new() } });

        var result = _controller.ConvertRomanNumeralToArabic("IIII");

        result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void ConvertRomanNumeralToArabic_InvalidInput_ErrorMessageInPlace()
    {
        _validatorMock.Validate(Arg.Is<string>(a => a.Equals("IIII")))
            .Returns(new ValidationResult { Errors = new List<ValidationFailure> { new() } });

        var result = (BadRequestObjectResult)_controller.ConvertRomanNumeralToArabic("IIII");

        result.Value.Should().BeOfType<InvalidRomanNumeralException>();
    }

    [Fact]
    public void ConvertRomanNumeralToArabic_ValidInput_ReturnArabicNumber()
    {
        _romanNumeralsMock.ConvertToArabic(Arg.Is<string>(a => a.Equals("IX"))).Returns(9);

        var result = (OkObjectResult)_controller.ConvertRomanNumeralToArabic("IX");

        result.Value.Should().Be(9);
    }
}