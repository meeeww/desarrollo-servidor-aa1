using BankAPI.Model;
namespace BankAPI.Data.Services;
public interface ICLienteRepository
{
    Task<IEnumerable<Cliente>> GetClientes();
    Task<Cliente> GetClienteById(int id);
    Task<Cliente> GetClienteByEmail(string DNI);
    Task<bool> InsertarCliente(Cliente cliente);
    Task<bool> UpdateCliente(Cliente cliente);
    Task<bool> DeleteCliente(Cliente cliente);
}