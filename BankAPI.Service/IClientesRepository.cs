using BankAPI.Model;
namespace BankAPI.Data.Services;
public interface IClientesRepository
{
    Task<IEnumerable<Cliente>> GetClientes();
    Task<Cliente> GetClienteById(int id);
    Task<Cliente> GetClienteByEmail(string email);
    Task<bool> InsertCliente(Cliente cliente);
    Task<bool> UpdateCliente(Cliente cliente);
    Task<bool> DeleteCliente(int id);
}