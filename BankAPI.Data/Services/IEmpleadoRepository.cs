using BankAPI.Model;

namespace BankAPI.Data.Services
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleados>> GetEmpleados();
        Task<Empleados> GetEmpleadoById(int id);
        Task<bool> InsertEmpleado(Empleados empleado);
        Task<bool> UpdateEmpleado(Empleados empleado);
        Task<bool> DeleteEmpleado(Empleados empleado);
    }
}
