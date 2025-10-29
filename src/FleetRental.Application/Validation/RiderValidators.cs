using FluentValidation;
using FleetRental.Application.DTOs;

namespace FleetRental.Application.Validation;

public class RiderCreateRequestValidator : AbstractValidator<RiderCreateRequest>
{
    public RiderCreateRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MinimumLength(3);
        RuleFor(x => x.DocumentNumber).NotEmpty().MinimumLength(11);
        RuleFor(x => x.Phone).NotEmpty().MinimumLength(8);
    }
}

public class RiderUpdateRequestValidator : AbstractValidator<RiderUpdateRequest>
{
    public RiderUpdateRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MinimumLength(3);
        RuleFor(x => x.DocumentNumber).NotEmpty().MinimumLength(11);
        RuleFor(x => x.Phone).NotEmpty().MinimumLength(8);
    }
}
