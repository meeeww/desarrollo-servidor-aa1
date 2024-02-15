namespace BankAPI.DTOs
{
    public class PedidoDto
    {
        public int ID_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Enviado { get; set; }
        public string MetodoPago { get; set; }
    }
}
