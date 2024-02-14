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

        public List<Cliente> GetClientes()
        {
            return _clientesRepository.GetClientes();
        }

        public Cliente GetClienteById(int id)
        {
            return _clientesRepository.GetClienteById(id);
        }

        public Cliente GetClienteByEmail(string email)
        {
            return _clientesRepository.GetClienteByEmail(email);
        }

        public Cliente InsertCliente(Cliente cliente)
        {
            _clientesRepository.InsertCliente(cliente);

            return cliente;
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clientesRepository.UpdateCliente(cliente);
        }
        public void DeleteCliente(int id)
        {
            _clientesRepository.DeleteCliente(id);
        }
    }
}

