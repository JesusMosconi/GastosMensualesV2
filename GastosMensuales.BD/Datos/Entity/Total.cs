using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.BD.Datos.Entity
{
    public class Total
    {

 
        public int Id { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Ingreso_Total { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Gasto_Fijo_Total { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Gasto_Diario_Total { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Ingreso_MenosGastosFijos_Total { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal SaldoActual { get; set; }

        public List<Ingreso>? Ingresos { get; set; } = new List<Ingreso>();
        public List<GastoFijo>? GastosFijos { get; set; } = new List<GastoFijo>();
        public List<GastoDiario>? GastosDiarios { get; set; } = new List<GastoDiario>();
    }
}
