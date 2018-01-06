using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientOccupation
{
    public class PatientOccupationValidator : AbstractValidator<PatientOccupation>
    {
        public PatientOccupationValidator()
        {
            RuleFor(c => c.Value).NotNull().WithMessage($"{nameof(PatientOccupation)} should not be null");
        }
    }
}
