using System;
using System.Collections.Generic;
using System.Text;
using BabylonCore.Application.Interfaces;
using BabylonCore.Application.Patients.Queries.GetPatientByIdQuery;

namespace BabylonCore.Application.Patients.Queries.GetPatientListQuery
{
    public class GetPatientListQuery : IGetPatientListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetPatientListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<PatientByListModel> Execute()
        {
            var patients =_databaseService.PatientsRepository.GetByFilter();

            var models = PatientByListModelMapper.CreateMapper().Map<List<PatientByListModel>>(patients);

            return models;
        }
    }
}
