namespace BankAPI.Model
{
    public class DetallePedido
    {
        public int ID_DetallePedido { get; set; }
        public int ID_Pedido { get; set; }
        public int ID_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
