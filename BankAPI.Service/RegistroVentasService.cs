using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services
{
    public class RegistroVentasService
    {
        private readonly IRegistroVentasRepository _registroVentasRepository;

        public RegistroVentasService(IRegistroVentasRepository registroVentasRepository)
        {
            _registroVentasRepository = registroVentasRepository;
        }

        public List<RegistroVentas> GetRegistrosVentas()
        {
            return _registroVentasRepository.GetRegistrosVentas();
        }
        public RegistroVentas GetRegistroVentasById(int id)
        {
            return _registroVentasRepository.GetRegistroVentasById(id);

        }
        public RegistroVentas GetRegistroVentasByIdEmpleado(int id)
        {
            return _registroVentasRepository.GetRegistroVentasByIdEmpleado(id);
        }
        public RegistroVentas InsertRegistroVentas(RegistroVentas registroVentas)
        {
            _registroVentasRepository.InsertRegistroVentas(registroVentas);

            return registroVentas;
        }
        public void UpdateRegistroVentas(RegistroVentas registroVentas)
        {
            _registroVentasRepository.UpdateRegistroVentas(registroVentas);
        }
        public void DeleteRegistroVentas(int id)
        {
            _registroVentasRepository.DeleteRegistroVentas(id);
        }
    }
}