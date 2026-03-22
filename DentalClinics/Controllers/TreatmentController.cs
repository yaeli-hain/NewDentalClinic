using DentalClinic.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;

        // GET: api/<TreatmentController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _treatmentService.GetTreatmentsAsync());
        }

        // GET api/<TreatmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var t=await _treatmentService.GetTreatmentByIdAsync(id);
            if (t != null)
                return Ok(t);
            return Ok();
        }

        // POST api/<TreatmentController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<TreatmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<TreatmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var tr = await _treatmentService.GetTreatmentByIdAsync(id);
            if (tr == null)
                return BadRequest();
            await _treatmentService.DeleteAsync(id);
            return Ok();
        }
    }
}
