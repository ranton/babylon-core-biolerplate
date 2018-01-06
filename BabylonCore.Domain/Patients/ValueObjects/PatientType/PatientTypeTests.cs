using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientType
{
    public class PatientSexTests
    {
        [Fact]
        public void Should_Valid_When_CharityIsSaved()
        {
            var sut = PatientType.Create("cHaRiTy");
            Assert.Equal("charity", sut.Value);
        }

        [Fact]
        public void Should_ErrorValidation_When_UnwantedPatientTypeIsSaved()
        {
            Assert.Throws<FluentValidation.ValidationException>(() => PatientType.Create("boom boom"));
        }
    }
}
