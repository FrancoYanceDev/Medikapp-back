using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ILogger<PacienteController> _logger;
        private PacienteService pacienteService;

        public PacienteController(ILogger<PacienteController> logger)
        {
            _logger = logger;
            pacienteService = new PacienteService();
        }

        [HttpGet("all")]

        public async Task<List<PacienteModel>>  GetAll()
        {
            return await this.pacienteService.GetAll();
        }

        [HttpGet]
        public ActionResult<List<PacienteModel>> GetByName([FromQuery] string nombre)
        {
            var paciente = pacienteService.GetByName(nombre);
            if (paciente == null)
            {
                return NotFound();
            }
            return paciente;
        }






        [HttpGet("id")]
        public ActionResult<PacienteModel> GetByID([FromQuery] int id_doctor)
        {
            var paciente = pacienteService.GetByID(id_doctor);
            if (paciente == null)
            {
                return NotFound();
            }
            return paciente;
        }


        [HttpPost]
        public ActionResult<PacienteModel> Create(PacienteModel paciente)
        {
            return pacienteService.Create(paciente);
        }


        [HttpPut]
        public async Task<ActionResult>  Update([FromQuery] int id_doctor, [FromBody]  PacienteModel paciente)
        {
            var _paciente = pacienteService.GetByID(id_doctor);

            if (_paciente == null)
            {
                return NotFound();
            }

            await pacienteService.Update(id_doctor, paciente);

            return new JsonResult(paciente);
        }



        [HttpDelete]
        public IActionResult Delete([FromQuery] int id_doctor)
        {
            var paciente = pacienteService.GetByID(id_doctor);

            if (paciente == null)
            {
                return NotFound();
            }

            pacienteService.Remove(paciente.id_doctor);

            return new JsonResult(paciente);
        }
    }
}
