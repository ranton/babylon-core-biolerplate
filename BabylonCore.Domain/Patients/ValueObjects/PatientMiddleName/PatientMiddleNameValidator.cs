using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientMiddleName
{
    public class PatientMiddleNameValidator : AbstractValidator<PatientMiddleName>
    {
        public PatientMiddleNameValidator()
        {
            RuleFor(x => x.Value).NotNull().NotEmpty()
                .WithMessage($"{nameof(PatientMiddleName)} should not be null or empty");
        }
    }
}
