using DentlClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Core.Services
{
    public interface IClientService
    {
        public Task<List<Client>> GetClientsAsync();
        public Task<Client> GetClientByIdAsync(int id );
        public Client Add(Client client);
        public Task<Client> UpdateAsync(int id, Client client);
        public Task DeleteAsync(int id);
    }
}
