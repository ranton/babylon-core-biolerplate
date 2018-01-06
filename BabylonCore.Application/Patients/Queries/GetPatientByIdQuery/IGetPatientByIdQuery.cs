using System;

namespace BabylonCore.Application.Patients.Queries.GetPatientByIdQuery
{
    public interface IGetPatientByIdQuery
    {
        PatientByIdModel Execute(Guid id);
    }
}
