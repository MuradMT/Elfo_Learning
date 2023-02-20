using Elfo_Learning.Models;
using FluentValidation;

namespace Elfo_Learning.Validation
{
    public class CityValidator:AbstractValidator<CityDto>
    {
        public CityValidator()
        {
            RuleFor(p=>p.Id).GreaterThan(0).WithMessage("The id must be positive");
        }
    }
}
