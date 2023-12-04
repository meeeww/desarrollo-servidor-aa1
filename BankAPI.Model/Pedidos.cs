namespace BankAPI.Model;
public class Pedidos
{
    public int ID_Pedido { get; set; }
    public int ID_Cliente { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public bool Enviado { get; set; }
    public decimal MetodoPago { get; set; }
}