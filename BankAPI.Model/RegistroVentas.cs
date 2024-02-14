using System.ComponentModel.DataAnnotations;

namespace BankAPI.Model
{
    public class RegistroVentas
    {
        [Key]
        public int ID_RegistroVentas { get; set; }
        public int ID_Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVentas { get; set; }
        public int TotalCostos { get; set; }
        public int TotalImpuestos { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
