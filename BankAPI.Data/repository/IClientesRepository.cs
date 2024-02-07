using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IClientesRepository
    {
        List<Cliente> GetClientes();
        Cliente GetClienteById(int id);
        Cliente GetClienteByEmail(string email);
        void InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
    }
}