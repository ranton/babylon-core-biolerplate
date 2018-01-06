using System.Collections.Generic;
using BabylonCore.Application.Patients.Queries.GetPatientByIdQuery;

namespace BabylonCore.Application.Patients.Queries.GetPatientListQuery
{
    public interface IGetPatientListQuery
    {
        List<PatientByListModel> Execute();
    }
}