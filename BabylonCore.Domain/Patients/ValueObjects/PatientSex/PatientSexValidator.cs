using System;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientSex
{
    public class PatientSexValidator : AbstractValidator<PatientSex>
    {
        public PatientSexValidator()
        {
            RuleFor(c => c.Value).NotNull().NotEmpty().WithMessage($"Sex should not be null or empty");
            RuleFor(c => c.Value).Must(c =>
                    c.Equals("male", StringComparison.InvariantCultureIgnoreCase) ||
                    c.Equals("female", StringComparison.InvariantCultureIgnoreCase))
                .WithMessage($"Sex must be male or female only");
        }
    }
}