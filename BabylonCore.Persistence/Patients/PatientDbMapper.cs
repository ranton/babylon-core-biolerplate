using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;
using BabylonCore.Domain.Patients;

namespace BabylonCore.Persistence.Patients
{
    public class PatientDbMapper
    {
        public static IMapper Create()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapField = x => true;
                cfg.ShouldMapProperty = propertyInfo => true;
                cfg.CreateMap<PatientDb, Patient>();
            }));
        }

        private PatientDbMapper()
        {

        }
    }
}
