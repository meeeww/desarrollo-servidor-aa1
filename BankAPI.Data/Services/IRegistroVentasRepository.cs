using BankAPI.Model;

namespace BankAPI.Data.Services
{
    public interface IRegistroVentasRepository
    {
        Task<IEnumerable<RegistroVentas>> GetRegistrosVentas();
        Task<RegistroVentas> GetRegistroVentasById(int id);
        Task<RegistroVentas> GetRegistroVentasByIdEmpleado(int id);
        Task<bool> InsertRegistroVentas(RegistroVentas registroVentas);
        Task<bool> UpdateRegistroVentas(RegistroVentas registroVentas);
        Task<bool> DeleteRegistroVentas(RegistroVentas registroVentas);
    }
}
