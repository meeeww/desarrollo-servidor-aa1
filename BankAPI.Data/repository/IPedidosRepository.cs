using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IPedidosRepository
    {
        List<Pedido> GetPedidos();
        Pedido GetPedidoById(int id);
        Pedido GetPedidoByDate(DateTime fecha);
        void InsertPedido(Pedido pedido);
        void UpdatePedido(Pedido pedido);
        void DeletePedido(int id);
    }
}