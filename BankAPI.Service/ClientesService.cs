using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services
{
    public class ClientesService
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesService(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public Task<IEnumerable<Cliente>> GetClientes()
        {
            return _clientesRepository.GetClientes();
        }

        public Task<Cliente> GetClienteById(int id)
        {
            return _clientesRepository.GetClienteById(id);
        }

        public Task<Cliente> GetClienteByEmail(string email)
        {
            return _clientesRepository.GetClienteByEmail(email);
        }

        public Task<bool> InsertCliente(Cliente cliente)
        {
            return _clientesRepository.InsertCliente(cliente);
        }

        public Task<bool> UpdateCliente(Cliente cliente)
        {
            return _clientesRepository.UpdateCliente(cliente);
        }
        public Task<bool> DeleteCliente(int id)
        {
            return _clientesRepository.DeleteCliente(id);
        }
    }
}

