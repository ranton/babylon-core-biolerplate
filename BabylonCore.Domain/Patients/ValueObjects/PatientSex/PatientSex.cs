using System.Collections.Generic;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientSex
{
    public class PatientSex : ValueObject<PatientSex>
    {
        private PatientSex(string value)
        {
            this.Value = value;
            new PatientSexValidator().ValidateAndThrow(this);
        }

        public string Value { get; }

        public static PatientSex Create(string value) => new PatientSex(value.ToLowerInvariant());

        public static implicit operator string(PatientSex sex) => sex.Value;
        public static explicit operator PatientSex(string sex) => Create(sex);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
