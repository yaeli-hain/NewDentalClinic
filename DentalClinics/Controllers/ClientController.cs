using DentalClinic.Core.Services;
using DentalClinic.Models;
using DentalClinic.Service;
using DentlClinic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        // GET: api/<ClientCotroller>
        [HttpGet]
        public async Task<IEnumerable<Client>> GetAsync()
        {
            return await _clientService.GetClientsAsync();
        }

        // GET api/<ClientCotroller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var c = await _clientService.GetClientByIdAsync(id);
            if(c!=null) 
                return Ok(c);
            return NotFound();
        }

        // POST api/<ClientCotroller>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Client value)
        {
            var cli = await _clientService.GetClientByIdAsync(value.id);
            if (cli == null)
            {
                var C = new Client
                {
                    id = value.id, // ודאי שזה שם השדה ב-ClientPostModel שלך
                    Name = value.Name,
                    Phone=value.Phone,
                    Identity=value.Identity,
                    Address=value.Address,
                    Appointments = value.Appointments   

                    // אם יש עוד שדות כמו טלפון או כתובת, הוסיפי אותם כאן באותו פורמט
                };
                var c =  _clientService.Add(C);
                return Ok(C);
            }
            ////409 - קונפליקט בבקשה
            return Conflict();
        }

        // PUT api/<ClientCotroller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Client value)
        {
            var cli = await _clientService.GetClientByIdAsync(id);
            if (cli == null)
                return BadRequest();
            await _clientService.UpdateAsync(id, cli);
            return Ok();
        }

        // DELETE api/<ClientCotroller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var app= await _clientService.GetClientByIdAsync(id);
            if (app == null)
                return BadRequest();
            _clientService.DeleteAsync(id);
            return Ok();

        }
    }
}
