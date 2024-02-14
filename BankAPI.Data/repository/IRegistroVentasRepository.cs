using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IRegistroVentasRepository
    {
        List<RegistroVentas> GetRegistrosVentas();
        RegistroVentas GetRegistroVentasById(int id);
        RegistroVentas GetRegistroVentasByIdEmpleado(int id);
        void InsertRegistroVentas(RegistroVentas registroVentas);
        void UpdateRegistroVentas(RegistroVentas registroVentas);
        void DeleteRegistroVentas(int id);
    }
}
