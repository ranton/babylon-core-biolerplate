using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientFirstName
{
    public class PatientFirstNameValidator : AbstractValidator<PatientFirstName>
    {
        public PatientFirstNameValidator()
        {
            RuleFor(x => x.Value).NotNull().NotEmpty()
                .WithMessage($"{nameof(PatientFirstName)} should not be null or empty");
        }
    }
}
