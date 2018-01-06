using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientPlaceOfBirth
{
    public class PatientPlaceOfBirthValidator : AbstractValidator<PatientPlaceOfBirth>
    {
        public PatientPlaceOfBirthValidator()
        {
            RuleFor(c => c.Value).NotNull().WithMessage($"{nameof(PatientPlaceOfBirth)} should not be null");
        }
    }
}