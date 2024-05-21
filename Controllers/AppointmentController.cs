using AppointAPI.Models;
using AppointAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppointAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var Appointments = await _repository.GetAllAppointmentsAsync();
            return Ok(Appointments);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Appointment>> GetAppointment(string code)
        {
            var Appointment = await _repository.GetAppointmentByCodeAsync(code);
            if (Appointment == null)
            {
                return NotFound();
            }
            return Ok(Appointment);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(AppointmentDTO Appointment)
        {
            bool inserted = await _repository.CreateAppointmentAsync(Appointment);
            if (!inserted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateAppointment(string code, AppointmentDTO Appointment)
        {
            if (code != Appointment.Code)
            {
                return BadRequest();
            }

            bool updated = await _repository.UpdateAppointmentAsync(Appointment);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteAppointment(string code)
        {
            bool deleted = await _repository.DeleteAppointmentAsync(code);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
