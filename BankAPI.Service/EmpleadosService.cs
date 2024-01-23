using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services;

public class EmpleadosService
{
    private readonly IEmpleadosRepository _empleadosRepository;

    public EmpleadosService(IEmpleadosRepository empleadosRepository)
    {
        _empleadosRepository = empleadosRepository;
    }

    public Task<IEnumerable<Empleado>> GetEmpleados()
    {
        return _empleadosRepository.GetEmpleados();
    }
    public Task<Empleado> GetEmpleadoById(int id)
    {
        return _empleadosRepository.GetEmpleadoById(id);
    }
    public Task<bool> InsertEmpleado(Empleado empleado)
    {
        return _empleadosRepository.InsertEmpleado(empleado);
    }
    public Task<bool> UpdateEmpleado(Empleado empleado)
    {
        return _empleadosRepository.UpdateEmpleado(empleado);
    }
    public Task<bool> DeleteEmpleado(int id)
    {
        return _empleadosRepository.DeleteEmpleado(id);
    }
}