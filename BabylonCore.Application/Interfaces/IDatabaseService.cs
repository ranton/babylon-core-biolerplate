namespace BabylonCore.Application.Interfaces
{
    public interface IDatabaseService
    {
        IPatientRepository PatientsRepository { get; }
    }
}
