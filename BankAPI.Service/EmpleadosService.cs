using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services
{
    public class EmpleadosService
    {
        private readonly IEmpleadosRepository _empleadosRepository;

        public EmpleadosService(IEmpleadosRepository empleadosRepository)
        {
            _empleadosRepository = empleadosRepository;
        }

        public List<Empleado> GetEmpleados()
        {
            return _empleadosRepository.GetEmpleados();
        }

        public Empleado GetEmpleadoById(int id)
        {
            return _empleadosRepository.GetEmpleadoById(id);
        }

        public Empleado InsertEmpleado(Empleado empleado)
        {
            _empleadosRepository.InsertEmpleado(empleado);

            return empleado;
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            _empleadosRepository.UpdateEmpleado(empleado);
        }
        public void DeleteEmpleado(int id)
        {
            _empleadosRepository.DeleteEmpleado(id);
        }
    }
}

