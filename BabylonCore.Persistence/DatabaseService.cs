using BabylonCore.Application.Interfaces;

namespace BabylonCore.Persistence
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService(IPatientRepository patientRepository)
        {
            PatientsRepository = patientRepository;
        }

        public IPatientRepository PatientsRepository { get; }
    }
}
