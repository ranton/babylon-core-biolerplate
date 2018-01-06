using System;

namespace BabylonCore.Application.Patients.Queries.GetPatientByIdQuery
{
    public class PatientByIdModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
        public string PatientType { get; set; }
    }
}
