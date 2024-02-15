using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IEmpleadosRepository
    {
        List<Empleado> GetEmpleados();
        Empleado GetEmpleadoById(int id);
        void InsertEmpleado(Empleado empleado);
        void UpdateEmpleado(Empleado empleado);
        void DeleteEmpleado(int id);
    }
}
