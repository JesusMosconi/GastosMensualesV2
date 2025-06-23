using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.BD.Datos.Entity
{
    public class GastoFijo
    {

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int TotalId { get; set; }
        public Total? Total { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage ="Tiene que ingresar el Detalle del gasto")]
        [MaxLength(100)]
        public required string Detalle { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Monto { get; set; }


        public  bool Pagado { get; set; }

        public string FechaPagado { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Total_A_Pagar { get; set; } 
    }
}
