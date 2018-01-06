using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientLastName
{
    public class PatientLastNameValidator : AbstractValidator<PatientLastName>
    {
        public PatientLastNameValidator()
        {
            RuleFor(x => x.Value).NotNull().NotEmpty()
                .WithMessage($"{nameof(PatientLastName)} should not be null or empty");
        }
    }
}
