using System;
using BabylonCore.Application.Patients.Commands.CreatePatientCommand;
using BabylonCore.Application.Patients.Commands.UpdatePatientCommand;
using BabylonCore.Application.Patients.Queries.GetPatientByIdQuery;
using BabylonCore.Application.Patients.Queries.GetPatientListQuery;
using Microsoft.AspNetCore.Mvc;

namespace BabylonCore.Api.Controllers
{
    [Route("api/patients")]
    public class PatientsController : Controller
    {
        private readonly IGetPatientListQuery _getPatientListQuery;
        private readonly IGetPatientByIdQuery _getPatientByIdQuery;
        private readonly ICreatePatientCommand _createPatientCommand;
        private readonly IUpdatePatientCommand _updatePatientCommand;


        public PatientsController(IGetPatientListQuery getPatientListQuery,
            IGetPatientByIdQuery getPatientByIdQuery,
            ICreatePatientCommand createPatientCommand,
            IUpdatePatientCommand updatePatientCommand)
        {
            _getPatientListQuery = getPatientListQuery;
            _getPatientByIdQuery = getPatientByIdQuery;
            _createPatientCommand = createPatientCommand;
            _updatePatientCommand = updatePatientCommand;
        }

        // GET api/patients
        [HttpGet]
        public IActionResult GetList()
        {
            var dto = _getPatientListQuery.Execute();
            return Ok(dto);
        }

        // GET api/patients/1
        [HttpGet("{id}", Name = "GetPatient")]
        public IActionResult GetPatient(Guid id)
        {
            var patientDto = _getPatientByIdQuery.Execute(id);
            return Ok(patientDto);
        }

        // POST api/patients
        [HttpPost]
        public IActionResult CreatePatient([FromBody] CreatePatientModel model)
        {
            var id = _createPatientCommand.Execute(model);
            return CreatedAtRoute("GetPatient", new { id }, "");
        }

        // PUT api/patients/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(string id, [FromBody] UpdatePatientModel model)
        {
            model.Id = new Guid(id);
            _updatePatientCommand.Execute(model);
            return Ok();
        }
    }
}
