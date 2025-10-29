using FluentValidation;
using FleetRental.Application.DTOs;

namespace FleetRental.Application.Validation;

public class MotorcycleCreateRequestValidator : AbstractValidator<MotorcycleCreateRequest>
{
    public MotorcycleCreateRequestValidator()
    {
        RuleFor(x => x.Plate).NotEmpty().MinimumLength(6);
        RuleFor(x => x.Model).NotEmpty();
        RuleFor(x => x.Year).InclusiveBetween(2000, DateTime.UtcNow.Year + 1);
    }
}

public class MotorcycleUpdateRequestValidator : AbstractValidator<MotorcycleUpdateRequest>
{
    public MotorcycleUpdateRequestValidator()
    {
        RuleFor(x => x.Plate).NotEmpty().MinimumLength(6);
        RuleFor(x => x.Model).NotEmpty();
        RuleFor(x => x.Year).InclusiveBetween(2000, DateTime.UtcNow.Year + 1);
    }
}
