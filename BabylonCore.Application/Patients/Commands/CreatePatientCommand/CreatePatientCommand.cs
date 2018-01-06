using System;
using System.Collections.Generic;
using System.Text;
using BabylonCore.Application.Interfaces;
using BabylonCore.Domain.Patients;
using BabylonCore.Domain.Patients.ValueObjects;
using BabylonCore.Domain.Patients.ValueObjects.PatientDateOfBirth;
using BabylonCore.Domain.Patients.ValueObjects.PatientFirstName;
using BabylonCore.Domain.Patients.ValueObjects.PatientLastName;
using BabylonCore.Domain.Patients.ValueObjects.PatientMiddleName;
using BabylonCore.Domain.Patients.ValueObjects.PatientOccupation;
using BabylonCore.Domain.Patients.ValueObjects.PatientPlaceOfBirth;
using BabylonCore.Domain.Patients.ValueObjects.PatientSex;
using BabylonCore.Domain.Patients.ValueObjects.PatientType;

namespace BabylonCore.Application.Patients.Commands.CreatePatientCommand
{
    public class CreatePatientCommand : ICreatePatientCommand
    {
        private readonly IDatabaseService _databaseService;

        public CreatePatientCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public Guid Execute(CreatePatientModel model)
        {
            var firstName = PatientFirstName.Create(model.FirstName);
            var middleName = PatientMiddleName.Create(model.MiddleName);
            var lastName = PatientLastName.Create(model.LastName);
            var dateOfBirth = PatientDateOfBirth.Create(model.DateOfBirth);
            var placeOfBirth = PatientPlaceOfBirth.Create(model.PlaceOfBirth);
            var sex = PatientSex.Create(model.Sex);
            var occupation = PatientOccupation.Create(model.Occupation);
            var patientType = PatientType.Create(model.PatientType);
            
            var patient = Patient.Create(firstName,
                middleName,
                lastName,
                dateOfBirth,
                placeOfBirth,
                occupation,
                sex,
                patientType);

            _databaseService.PatientsRepository.Add(patient);

            return patient.Id;
        }
    }
}
