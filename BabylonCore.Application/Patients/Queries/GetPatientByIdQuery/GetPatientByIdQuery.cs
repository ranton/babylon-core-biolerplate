using System;
using System.Collections.Generic;
using System.Text;
using BabylonCore.Application.Interfaces;

namespace BabylonCore.Application.Patients.Queries.GetPatientByIdQuery
{
    public class GetPatientByIdQuery : IGetPatientByIdQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetPatientByIdQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public PatientByIdModel Execute(Guid id)
        {
            var patient = _databaseService.PatientsRepository.GetById(id);

            var patientModel = PatientByIdModelMapper.CreateMapper().Map<PatientByIdModel>(patient);
            return patientModel;
        }
    }
}
