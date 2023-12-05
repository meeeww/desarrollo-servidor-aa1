namespace BankAPI.Model
{
    public class RegistroVentas
    {
        public int ID_RegistroVentas { get; set; }
        public int ID_Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVentas { get; set; }
        public int TotalCostos { get; set; }
        public int TotalImpuestos { get; set; }
    }
}
