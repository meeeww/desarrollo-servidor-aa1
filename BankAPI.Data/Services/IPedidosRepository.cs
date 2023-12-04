using BankAPI.Model;

namespace BankAPI.Data.Services
{
    public interface IPedidosRepository
    {
        Task<IEnumerable<Pedidos>> GetPedidos();
        Task<Pedidos> GetPedidoById(int id);
        Task<Pedidos> GetPedidoByDate(DateTime fecha);
        Task<bool> InsertPedido(Pedidos pedido);
        Task<bool> UpdatePedido(Pedidos pedido);
        Task<bool> DeletePedido(Pedidos pedido);
    }
}