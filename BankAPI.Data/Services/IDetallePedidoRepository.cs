using BankAPI.Model;

namespace BankAPI.Data.Services
{
    public interface IDetallePedidoRepository
    {
        Task<IEnumerable<DetallePedidos>> GetDetallesPedido();
        Task<DetallePedidos> GetDetallePedidoById(int id);
        Task<bool> InsertDetallePedido(DetallePedidos detallePedido);
        Task<bool> UpdateDetallePedido(DetallePedidos detallePedido);
        Task<bool> DeleteDetallePedido(DetallePedidos detallePedido);
    }
}
