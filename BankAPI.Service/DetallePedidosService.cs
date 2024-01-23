using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services;

public class DetallePedidosService
{
    private readonly IDetallePedidosRepository _detallePedidoRepository;

    public DetallePedidosService(IDetallePedidosRepository detallePedidosRepository)
    {
        _detallePedidoRepository = detallePedidosRepository;
    }

    public Task<IEnumerable<DetallePedido>> GetDetallesPedido()
    {
        return _detallePedidoRepository.GetDetallesPedido();
    }
    public Task<DetallePedido> GetDetallePedidoById(int id)
    {
        return _detallePedidoRepository.GetDetallePedidoById(id);
    }
    public Task<bool> InsertDetallePedido(DetallePedido detallePedido)
    {
        return _detallePedidoRepository.InsertDetallePedido(detallePedido);
    }
    public Task<bool> UpdateDetallePedido(DetallePedido detallePedido)
    {
        return _detallePedidoRepository.UpdateDetallePedido(detallePedido);
    }
    public Task<bool> DeleteDetallePedido(int id)
    {
        return _detallePedidoRepository.DeleteDetallePedido(id);
    }
}
