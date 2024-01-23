using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services;

public class RegistroVentasService
{
    private readonly IRegistroVentasRepository _registroVentasRepository;

    public RegistroVentasService(IRegistroVentasRepository registroVentasRepository)
    {
        _registroVentasRepository = registroVentasRepository;
    }

    public Task<IEnumerable<RegistroVentas>> GetRegistrosVentas()
    {
        return _registroVentasRepository.GetRegistrosVentas();
    }
    public Task<RegistroVentas> GetRegistroVentasById(int id)
    {
        return _registroVentasRepository.GetRegistroVentasById(id);

    }
    public Task<RegistroVentas> GetRegistroVentasByIdEmpleado(int id)
    {
        return _registroVentasRepository.GetRegistroVentasByIdEmpleado(id);
    }
    public Task<bool> InsertRegistroVentas(RegistroVentas registroVentas)
    {
        return _registroVentasRepository.InsertRegistroVentas(registroVentas);
    }
    public Task<bool> UpdateRegistroVentas(RegistroVentas registroVentas)
    {
        return _registroVentasRepository.UpdateRegistroVentas(registroVentas);
    }
    public Task<bool> DeleteRegistroVentas(int id)
    {
        return _registroVentasRepository.DeleteRegistroVentas(id);
    }


}