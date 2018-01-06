using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientSex
{
    public class PatientSexTests
    {
        [Fact]
        public void Should_Valid_When_MaleOrFemailIsSaved()
        {
            var sut = PatientSex.Create("maLe");
            Assert.Equal("male", sut.Value);

            var sut2 = PatientSex.Create("feMaLe");
            Assert.Equal("female", sut2.Value);
        }

        [Fact]
        public void Should_ErrorValidation_When_UnwantedSexIsSaved()
        {
            Assert.Throws<FluentValidation.ValidationException>(() => PatientSex.Create("boom boom"));
        }
    }
}
