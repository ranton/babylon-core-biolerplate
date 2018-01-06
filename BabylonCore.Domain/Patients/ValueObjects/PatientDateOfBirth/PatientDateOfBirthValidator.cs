using System;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientDateOfBirth
{
    public class PatientDateOfBirthValidator : AbstractValidator<PatientDateOfBirth>
    {
        public PatientDateOfBirthValidator()
        {
            RuleFor(x => x.Value).NotEqual(default(DateTimeOffset))
                .WithMessage($"{nameof(PatientDateOfBirth)} should not be null or empty");
            RuleFor(x => x.Value).LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage($"{nameof(PatientDateOfBirth)} should not be greater than the current time");
        }
    }
}