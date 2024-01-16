using BankAPI.Model;

namespace BankAPI.Services
{
    public interface IPedidosRepository
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedidoById(int id);
        Task<Pedido> GetPedidoByDate(DateTime fecha);
        Task<bool> InsertPedido(Pedido pedido);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(int id);
    }
}