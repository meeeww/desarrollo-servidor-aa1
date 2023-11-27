namespace BankAPI.Model;
public class Pedido
{
    public int ID_Pedido { get; set; }
    public int ID_Cliente { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
}