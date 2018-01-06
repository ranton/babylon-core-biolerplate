using System;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientType
{
    public class PatientTypeValidator : AbstractValidator<PatientType>
    {
        public PatientTypeValidator()
        {
            RuleFor(c => c.Value).NotNull().NotEmpty().WithMessage($"PatientType should not be null or empty");
            RuleFor(c => c.Value).Must(c =>
                    c.Equals("charity", StringComparison.InvariantCultureIgnoreCase) ||
                    c.Equals("private", StringComparison.InvariantCultureIgnoreCase))
                .WithMessage($"PatientType must be charity or private only");
        }
    }
}