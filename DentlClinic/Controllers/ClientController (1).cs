using DentalClinic.core;
using DentalClinic.core.Models;
using DentlClinic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web.Mvc;

namespace DentalClinic.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            var clients = _clientRepository.GetAllClients();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientRepository.AddClient(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }
    }
}
