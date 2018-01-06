using System;
using System.Collections.Generic;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientDateOfBirth
{
    public class PatientDateOfBirth : ValueObject<PatientDateOfBirth>
    {

        public DateTimeOffset Value { get; }

        public static PatientDateOfBirth Create(DateTimeOffset dateTime)
        {
            return new PatientDateOfBirth(dateTime);
        } 

        private PatientDateOfBirth(DateTimeOffset value)
        {
            Value = value;
            new PatientDateOfBirthValidator().ValidateAndThrow(this);
        }

        public static implicit operator DateTimeOffset(PatientDateOfBirth dateOfBirth)
        {
            return dateOfBirth.Value;
        }

        public static explicit operator PatientDateOfBirth(DateTimeOffset dateOfBirth)
        {
            return Create(dateOfBirth);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
