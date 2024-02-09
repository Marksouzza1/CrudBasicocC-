
using Crud.Domain;

namespace Crud.Repository
{
    public interface ICliente
    {
        void Add(Cliente cliente);
        List<Cliente> GetAll();
        Cliente Get(int id);
        void Update(Cliente cliente);
        Task<int> SaveChangesAsync();
        void Remove(Cliente cliente);
    }
}
