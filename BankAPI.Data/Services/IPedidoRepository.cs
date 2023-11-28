using BankAPI.Model;

namespace BankAPI.Data.Services
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedidoById(int id);
        Task<Pedido> GetPedidoByDate(DateTime fecha);
        Task<bool> InsertPedido(Pedido pedido);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(Pedido pedido);
    }
}