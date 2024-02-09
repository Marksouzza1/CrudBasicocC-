

using Crud.Domain;
using Crud.Repository;
using Crude.Aplication.ViewModel;

namespace Crud.Service
{
    public class ClienteService
    {
        private readonly ICliente _clienteRepository;

        public ClienteService(ICliente clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<Cliente> CriarCliente(CriarCliente viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var cliente = new Cliente(viewModel.Nome, viewModel.Email, viewModel.Telefone, viewModel.Cpf);

             _clienteRepository.Add(cliente);
            await _clienteRepository.SaveChangesAsync();

            return cliente;
        }

        public List<Cliente> GetAll() 
        { 
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(int id) 
        {
            var cliente = _clienteRepository.Get(id);
            return cliente;
        }

        public void AtualizarCliente (int Id , CriarCliente model)
        {
           var cliente = _clienteRepository.Get(Id);

            cliente.Nome = model.Nome;
            cliente.Cpf = model.Cpf;
            cliente.Telefone = model.Telefone;
            cliente.Email = model.Email;

            _clienteRepository.Update(cliente);
            _clienteRepository.SaveChangesAsync ();                       

        }

        public void RemoverCLiente(int Id)
        {
            var cliente = _clienteRepository.Get(Id);
            _clienteRepository.Remove(cliente);
        }
    }
}
