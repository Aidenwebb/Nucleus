namespace Nucleus.Application.Countries.Commands.CreateCountry;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(validator => validator.Identifier)
            .MaximumLength(10)
            .NotEmpty();
        RuleFor(v => v.Name)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(v => v.CountryCode)
            .MaximumLength(2)
            .Matches( @"\b[A-Z]{2}\b").WithMessage("Country code must be in valid ISO 3166-1 alpha-2 format. IE: Two upper case letters. EG: 'GB'")
            .NotEmpty();
    }
}
