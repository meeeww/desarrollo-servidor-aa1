namespace BankAPI.Model
{
    public class Empleado
    {
        public int ID_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}
