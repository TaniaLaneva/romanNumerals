using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace RomanNumerals
{
    [ApiController]
    [Route("[controller]")]
    public class RomanNumeralController : ControllerBase
    {
        private readonly ILogger<RomanNumeralController> _logger;
        private readonly IRomanNumerals _romanNumerals;
        private readonly IValidator<string> _validator;

        public RomanNumeralController(ILogger<RomanNumeralController> logger, IRomanNumerals romanNumerals,
            IValidator<string> validator)
        {
            _validator = validator;
            _logger = logger;
            _romanNumerals = romanNumerals;
        }

        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConvertRomanNumeralToArabic([FromQuery] string romanNumeral)
        {
            var validationResult = _validator.Validate(romanNumeral);
            
            if (validationResult.IsValid) return Ok(_romanNumerals.ConvertToArabic(romanNumeral));

            _logger.LogError("attempt to convert invalid roman numeral {InvalidRomanNumeral}", romanNumeral);
            return BadRequest(new InvalidRomanNumeralException(romanNumeral));
        }
    }
}