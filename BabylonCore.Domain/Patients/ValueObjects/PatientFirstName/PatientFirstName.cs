using System.Collections.Generic;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientFirstName
{
    public class PatientFirstName : ValueObject<PatientFirstName>
    {
        private PatientFirstName(string value)
        {
            this.Value = value;
            new PatientFirstNameValidator().ValidateAndThrow(this);
        }

        public string Value { get; }

        public static PatientFirstName Create(string value)
        {
            var vo = new PatientFirstName(value);
            return vo;
        }

        

        public static implicit operator string(PatientFirstName firstName)
        {
            return firstName.Value;
        }

        public static explicit operator PatientFirstName(string firstName)
        {
            return Create(firstName);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
