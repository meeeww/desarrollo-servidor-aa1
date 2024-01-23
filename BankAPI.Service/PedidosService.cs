using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services;

public class PedidosService
{
    private readonly IPedidosRepository _pedidosRepository;

    public PedidosService(IPedidosRepository pedidosRepository)
    {
        _pedidosRepository = pedidosRepository;
    }

    public Task<IEnumerable<Pedido>> GetPedidos()
    {
        return _pedidosRepository.GetPedidos();
    }
    public Task<Pedido> GetPedidoById(int id)
    {
        return _pedidosRepository.GetPedidoById(id);
    }
    public Task<Pedido> GetPedidoByDate(DateTime fecha)
    {
        return _pedidosRepository.GetPedidoByDate(fecha);
    }
    public Task<bool> InsertPedido(Pedido pedido)
    {
        return _pedidosRepository.InsertPedido(pedido);
    }
    public Task<bool> UpdatePedido(Pedido pedido)
    {
        return _pedidosRepository.UpdatePedido(pedido);
    }
    public Task<bool> DeletePedido(int id)
    {
        return _pedidosRepository.DeletePedido(id);
    }

}
