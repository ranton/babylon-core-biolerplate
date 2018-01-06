using System.Collections.Generic;
using System.Globalization;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientType
{
    public class PatientType : ValueObject<PatientType>
    {
        public string Value { get; }

        public PatientType(string value)
        {
            this.Value = value;
            new PatientTypeValidator().ValidateAndThrow(this);
        }

        public static PatientType Create(string value)
        {
            value = value.ToLower(CultureInfo.InvariantCulture);
            return new PatientType(value);
        }



        public static implicit operator string(PatientType patientType)
        {
            return patientType.Value;
        }

        public static explicit operator PatientType(string patientType)
        {
            return Create(patientType);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
