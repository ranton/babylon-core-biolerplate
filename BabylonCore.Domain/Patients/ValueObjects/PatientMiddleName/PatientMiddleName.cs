using System.Collections.Generic;
using BabylonCore.Domain.Common;
using FluentValidation;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientMiddleName
{
    public class PatientMiddleName : ValueObject<PatientMiddleName>
    {
        private PatientMiddleName(string value)
        {
            this.Value = value;
            new PatientMiddleNameValidator().Validate(this);
        }

        public string Value { get; }

        public static PatientMiddleName Create(string value) 
        {
            var vo = new PatientMiddleName(value);
            return vo;
        }

        public static implicit operator string(PatientMiddleName middleName) => middleName.Value;
        public static explicit operator PatientMiddleName(string sex) => Create(sex);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
