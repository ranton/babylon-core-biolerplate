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

namespace BabylonCore.Application.Patients.Commands.UpdatePatientCommand
{
    public class UpdatePatientCommand : IUpdatePatientCommand
    {
        private readonly IDatabaseService _databaseService;

        public UpdatePatientCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void Execute(UpdatePatientModel model)
        {
            var dateOfBirth = PatientDateOfBirth.Create(model.DateOfBirth);
            var sex = PatientSex.Create(model.Sex);
            var patientType = PatientType.Create(model.PatientType);
            var firstName = PatientFirstName.Create(model.FirstName);
            var middleName = PatientMiddleName.Create(model.MiddleName);
            var lastName = PatientLastName.Create(model.LastName);
            var occupation = PatientOccupation.Create(model.Occupation);
            var placeOfBirth = PatientPlaceOfBirth.Create(model.PlaceOfBirth);

            var patient = _databaseService.PatientsRepository.GetById(model.Id);

            patient.FirstName = firstName;
            patient.MiddleName = middleName;
            patient.LastName = lastName;
            patient.DateOfBirth = dateOfBirth;
            patient.PatientType = patientType;
            patient.Occupation = occupation;
            patient.PlaceOfBirth = placeOfBirth;
            patient.Sex = sex;

            _databaseService.PatientsRepository.Update(patient);         
        }
    }
}
