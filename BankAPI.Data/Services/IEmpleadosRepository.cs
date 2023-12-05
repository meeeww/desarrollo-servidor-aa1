using BankAPI.Model;

namespace BankAPI.Data.Services
{
    public interface IEmpleadosRepository
    {
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleadoById(int id);
        Task<bool> InsertEmpleado(Empleado empleado);
        Task<bool> UpdateEmpleado(Empleado empleado);
        Task<bool> DeleteEmpleado(int id);
    }
}
