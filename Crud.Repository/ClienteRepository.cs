
using Crud.Domain;
using Crud.Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class ClienteRepository : ICliente
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente Get(int id)
        {
            return _context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        public void Remove(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
