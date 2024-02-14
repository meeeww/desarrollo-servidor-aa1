using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IDetallePedidosRepository
    {
        List<DetallePedido> GetDetallesPedido();
        DetallePedido GetDetallePedidoById(int id);
        void InsertDetallePedido(DetallePedido detallePedido);
        void UpdateDetallePedido(DetallePedido detallePedido);
        void DeleteDetallePedido(int id);
    }
}
