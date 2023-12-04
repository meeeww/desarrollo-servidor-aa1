using BankAPI.Model;
namespace BankAPI.Data.Services;
public interface IClienteRepository
{
    Task<IEnumerable<Clientes>> GetClientes();
    Task<Clientes> GetClienteById(int id);
    Task<Clientes> GetClienteByEmail(string DNI);
    Task<bool> InsertarCliente(Clientes cliente);
    Task<bool> UpdateCliente(Clientes cliente);
    Task<bool> DeleteCliente(Clientes cliente);
}