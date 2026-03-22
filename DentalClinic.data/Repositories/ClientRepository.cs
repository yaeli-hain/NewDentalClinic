//using DentalClinic.core;
//using DentalClinic.Core.Models;
using DentalClinic.Core.Repositories;
using DentlClinic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DentalClinic.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task< List<Client>> GetClientsAsync()
        {
            return await _context.Clients.Include(c => c.Appointments).ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(a => a.id == id);
        }

        public Client Add(Client client)
        {
            _context.Clients.Add(client);
            return client;
        }

        public async Task<Client> UpdateAsync(int id, Client client)
        {
            var a = await GetClientByIdAsync(client.id);
            a.Name = client.Name;
            a.Address = client.Address;
            a.Phone = client.Phone;
            return a;
        }

        // בתוך הקובץ ClientRepository.cs

        public async Task DeleteAsync(int id)
        {
            // כאן את צריכה למצוא את הלקוח לפי תעודת הזהות (Identity) ולמחוק אותו
            var client = _context.Clients.FirstOrDefault(c => c.id == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
