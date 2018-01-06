using System.Collections.Generic;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientOccupation
{
    public class PatientOccupation : ValueObject<PatientOccupation>
    {
        private PatientOccupation(string value)
        {
            this.Value = value;
            new PatientOccupationValidator().ValidateAndThrow(this);
        }

        public string Value { get; }

        public static PatientOccupation Create(string value)
        {
            return new PatientOccupation(value);
        }

        public static implicit operator string(PatientOccupation value)
        {
            return value.Value;
        }

        public static explicit operator PatientOccupation(string value)
        {
            return Create(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
