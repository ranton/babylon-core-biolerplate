using System;

namespace BabylonCore.Application.Patients.Commands.CreatePatientCommand
{
    public interface ICreatePatientCommand
    {
        Guid Execute(CreatePatientModel model);
    }
}
