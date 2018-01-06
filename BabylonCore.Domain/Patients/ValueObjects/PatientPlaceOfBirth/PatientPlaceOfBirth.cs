using System.Collections.Generic;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientPlaceOfBirth
{
    public class PatientPlaceOfBirth : ValueObject<PatientPlaceOfBirth>
    {
        private PatientPlaceOfBirth(string value)
        {
            this.Value = value;
            new PatientPlaceOfBirthValidator().ValidateAndThrow(this);
        }

        public string Value { get; }

        public static PatientPlaceOfBirth Create(string value)
        {
            return new PatientPlaceOfBirth(value);
        }

        
        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(PatientPlaceOfBirth value)
        {
            return value.Value;
        }

        public static explicit operator PatientPlaceOfBirth(string value)
        {
            return Create(value);
        }
    }
}
