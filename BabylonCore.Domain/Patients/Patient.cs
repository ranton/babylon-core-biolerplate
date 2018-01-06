using System;
using BabylonCore.Domain.Common;
using BabylonCore.Domain.Patients.ValueObjects.PatientDateOfBirth;
using BabylonCore.Domain.Patients.ValueObjects.PatientFirstName;
using BabylonCore.Domain.Patients.ValueObjects.PatientLastName;
using BabylonCore.Domain.Patients.ValueObjects.PatientMiddleName;
using BabylonCore.Domain.Patients.ValueObjects.PatientOccupation;
using BabylonCore.Domain.Patients.ValueObjects.PatientPlaceOfBirth;
using BabylonCore.Domain.Patients.ValueObjects.PatientSex;
using BabylonCore.Domain.Patients.ValueObjects.PatientType;

namespace BabylonCore.Domain.Patients
{
    public class Patient : Entity
    {
        private DateTimeOffset _dateOfBirth;
        public PatientDateOfBirth DateOfBirth
        {
            get => (PatientDateOfBirth)_dateOfBirth;
            set => _dateOfBirth = value;
        }

        private string _sex;
        public PatientSex Sex
        {
            get => (PatientSex)_sex;
            set => _sex = value;
        }

        private string _patientType;
        public PatientType PatientType
        {
            get => (PatientType)_patientType;
            set => _patientType = value;
        }

        private string _firstName;
        public PatientFirstName FirstName
        {
            get => (PatientFirstName)_firstName;
            set => _firstName = value;
        }

        private string _middleName;
        public PatientMiddleName MiddleName
        {
            get => (PatientMiddleName)_middleName;
            set => _middleName = value;
        }

        private string _lastName;
        public PatientLastName LastName
        {
            get => (PatientLastName)_lastName;
            set => _lastName = value;
        }

        private string _placeOfBirth;
        public PatientPlaceOfBirth PlaceOfBirth
        {
            get => (PatientPlaceOfBirth)_placeOfBirth;
            set => _placeOfBirth = value;
        }

        private string _occupation;
        public PatientOccupation Occupation
        {
            get => (PatientOccupation)_occupation;
            set => _occupation = value;
        }


        protected Patient(
            Guid id,
            PatientFirstName firstName,
            PatientMiddleName middleName,
            PatientLastName lastName,
            PatientDateOfBirth dateOfBirth,
            PatientPlaceOfBirth placeOfBirth,
            PatientOccupation occupation,
            PatientSex sex,
            PatientType patientType)
        {

            Id = id;
            DateOfBirth = dateOfBirth ?? throw new ArgumentNullException(nameof(dateOfBirth));
            PatientType = patientType ?? throw new ArgumentNullException(nameof(patientType));
            Sex = sex ?? throw new ArgumentNullException(nameof(sex));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            PlaceOfBirth = placeOfBirth ?? throw new ArgumentNullException(nameof(placeOfBirth));
            Occupation = occupation ?? throw new ArgumentNullException(nameof(occupation));

        }

        public static Patient Create(
            PatientFirstName firstName,
            PatientMiddleName middleName,
            PatientLastName lastName,
            PatientDateOfBirth dateOfBirth,
            PatientPlaceOfBirth placeOfBirth,
            PatientOccupation occupation,
            PatientSex sex,
            PatientType patientType)
        {


            return new Patient(
                 Guid.NewGuid(),
                 firstName,
                 middleName,
                 lastName,
                 dateOfBirth,
                 placeOfBirth,
                 occupation,
                 sex,
                 patientType);
        }
    }
}
