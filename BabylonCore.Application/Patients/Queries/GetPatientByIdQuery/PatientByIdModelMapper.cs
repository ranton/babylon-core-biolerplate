using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using BabylonCore.Domain.Patients;

namespace BabylonCore.Application.Patients.Queries.GetPatientByIdQuery
{
    public class PatientByIdModelMapper 
    {
        public static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapField = x => true;
                cfg.ShouldMapProperty = propertyInfo => true;
                cfg.CreateMap<Patient, PatientByIdModel>()
                    .ForMember(x => x.FirstName, opt => opt.MapFrom(b => b.FirstName.Value))
                    .ForMember(x => x.LastName, opt => opt.MapFrom(b => b.LastName.Value))
                    .ForMember(x => x.MiddleName, opt => opt.MapFrom(b => b.MiddleName.Value))
                    .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(b => b.DateOfBirth.Value))
                    .ForMember(x => x.Occupation, opt => opt.MapFrom(b => b.Occupation.Value))
                    .ForMember(x => x.PatientType, opt => opt.MapFrom(b => b.PatientType.Value))
                    .ForMember(x => x.PlaceOfBirth, opt => opt.MapFrom(b => b.PlaceOfBirth.Value))
                    .ForMember(x => x.Sex, opt => opt.MapFrom(b => b.Sex.Value));
            }));
        }

        private PatientByIdModelMapper() { }
    }
}
