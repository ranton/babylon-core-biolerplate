using System;
using System.Collections.Generic;
using AutoMapper;
using BabylonCore.Application.Interfaces;
using BabylonCore.Domain.Patients;
using Couchbase;
using Couchbase.Core;
using Couchbase.N1QL;


namespace BabylonCore.Persistence.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IBucket _bucket;

        public PatientRepository(IPatientBucketProvider bucketPatientProvider)
        {
            _bucket = bucketPatientProvider.GetBucket();
        }

        public void Add(Patient entity)
        {

            var model = new PatientDb()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth.Value,
                PlaceOfBirth = entity.PlaceOfBirth.Value,
                Occupation = entity.Occupation,
                Sex = entity.Sex.Value,
                PatientType = entity.PatientType.Value
            };

            var patient = new Document<PatientDb>()
            {
                Id = entity.Id.ToString(),
                Content = model
            };
            _bucket.Insert(patient);
        }


        public void Delete(Guid id)
        {
            _bucket.Remove($"Patient_{id}");
        }


        public List<Patient> GetByFilter(params KeyValuePair<string, string>[] criteria)
        {
            var n1ql = "select g.* from patients g";
            var query = QueryRequest.Create(n1ql);

            var result = _bucket.Query<PatientDb>(query);
            var rowsDb = result.Rows;

            var mapper = PatientDbMapper.Create();
            
            var patients = mapper.Map<List<Patient>>(rowsDb);
            return patients;
        }

        public Patient GetById(Guid id)
        {
            var document = _bucket.GetDocument<PatientDb>(id.ToString());

            var mapper = PatientDbMapper.Create();
            var patient = mapper.Map<Patient>(document.Content);
            return patient;
        }

        public void Update(Patient entity)
        {

            var document = _bucket.GetDocument<PatientDb>(entity.Id.ToString());
            var documentContent = document.Content;
            documentContent.DateOfBirth = entity.DateOfBirth.Value;
            documentContent.FirstName = entity.FirstName;
            documentContent.MiddleName = entity.MiddleName;
            documentContent.LastName = entity.LastName.Value;
            documentContent.Occupation = entity.Occupation.Value;
            documentContent.PatientType = entity.PatientType.Value;
            documentContent.PlaceOfBirth = entity.PlaceOfBirth.Value;
            documentContent.Sex = entity.Sex.Value;

            var doc = _bucket.Replace(document.Document);
            if (!doc.Success)
            {
                throw new Exception($"Update failed {doc.Message} {doc.Exception}");
            }
        }
    }

    
}
