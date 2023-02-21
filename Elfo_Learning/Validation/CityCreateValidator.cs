using Elfo_Learning.Models;
using FluentValidation;

namespace Elfo_Learning.Validation
{
    public class CityCreateValidator:AbstractValidator<CityCreateDto>
    {
        public CityCreateValidator()
        {
            RuleFor(p=>p.Name).NotNull().WithMessage("you must be giv name");
        }
    }
}
