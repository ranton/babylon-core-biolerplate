using System.Collections.Generic;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientLastName
{
    public class PatientLastName : ValueObject<PatientLastName>
    {
        private PatientLastName(string value)
        {
            this.Value = value;
            new PatientLastNameValidator().ValidateAndThrow(this);
        }

        public string Value { get; }

        public static PatientLastName Create(string value)
        {
            var vo = new PatientLastName(value);
            return vo;
        }

        public static implicit operator string(PatientLastName value)
        {
            return value.Value;
        }

        public static explicit operator PatientLastName(string value)
        {
            return Create(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
