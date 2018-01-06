using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Xunit;

namespace BabylonCore.Domain.Patients.ValueObjects.PatientDateOfBirth
{
    
    public class PatientDateOfBirthTests
    {
        [Fact]
        public void Should_BeValidationError_When_ItIsGreaterThanOrEqualToDateToday()
        {
            Assert.Throws<ValidationException>(() => PatientDateOfBirth.Create(DateTime.UtcNow.AddDays(1)));
        }

        [Fact]
        public void Should_BeValid_When_DateIsLesserThanTodaysDate()
        {
            var sut = PatientDateOfBirth.Create(new DateTimeOffset(new DateTime(1988, 1, 1)));
            Assert.InRange(sut.Value, new DateTimeOffset(new DateTime(1988, 1, 1)), new DateTimeOffset(new DateTime(1988, 1, 1)));
            
        }
    }
}
