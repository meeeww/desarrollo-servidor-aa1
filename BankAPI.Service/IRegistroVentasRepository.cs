using BankAPI.Model;

namespace BankAPI.Services
{
    public interface IRegistroVentasRepository
    {
        Task<IEnumerable<RegistroVentas>> GetRegistrosVentas();
        Task<RegistroVentas> GetRegistroVentasById(int id);
        Task<RegistroVentas> GetRegistroVentasByIdEmpleado(int id);
        Task<bool> InsertRegistroVentas(RegistroVentas registroVentas);
        Task<bool> UpdateRegistroVentas(RegistroVentas registroVentas);
        Task<bool> DeleteRegistroVentas(int id);
    }
}
