using DentalClinic.Core.Repositories;
using DentalClinic.Core.Services;
using DentlClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        public Client Add(Client client)
        {
            return _clientRepository.Add(client);
        }

        public async Task<Client> UpdateAsync(int id, Client client)
        {
            return await _clientRepository.UpdateAsync(id, client);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }

    }
}
