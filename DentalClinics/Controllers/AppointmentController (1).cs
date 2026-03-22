using DentalClinic.Core.Services;
using DentalClinic.Service;
using DentlClinic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _AppointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _AppointmentService = appointmentService;
        }


        // GET: api/<AppointmentController>
        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetAsync()
        {
            return await _AppointmentService.GetAppointmentsAsync();
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
           var a = await _AppointmentService.GetByIdAsync(id);
            if (a != null)
            {
                return Ok(a);
            }
            return NotFound();
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Appointment appointment)
        {
            var app = await _AppointmentService.GetByIdAsync(appointment.Id);
            if (app == null)
            {
                var a = _AppointmentService.Add(appointment);
                return Ok(a);
            }
            return Conflict();
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Appointment value)
        {
            var app=await _AppointmentService.GetByIdAsync(id);
            if (app == null)
                return BadRequest();
            await _AppointmentService.UpdateAsync(id, app);
            return Ok();
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var app= await _AppointmentService.GetByIdAsync(id);
            if(app == null)
                return BadRequest();
            _AppointmentService.DeleteAsync(id);
            return Ok();
        }
    }
}
