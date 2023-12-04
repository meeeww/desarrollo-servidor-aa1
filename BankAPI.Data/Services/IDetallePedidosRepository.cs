using BankAPI.Model;

namespace BankAPI.Data.Services
{
    public interface IDetallePedidosRepository
    {
        Task<IEnumerable<DetallePedido>> GetDetallesPedido();
        Task<DetallePedido> GetDetallePedidoById(int id);
        Task<bool> InsertDetallePedido(DetallePedido detallePedido);
        Task<bool> UpdateDetallePedido(DetallePedido detallePedido);
        Task<bool> DeleteDetallePedido(DetallePedido detallePedido);
    }
}
