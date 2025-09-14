using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.BD.Datos.Entity
{
    public class GastoDiario : EntityBase
    {

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
       

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage ="Debe aclarar el detalle")]
        [MaxLength(100, ErrorMessage ="Ha excedido el limite de caracteres")]
        public required string Detalle {get; set; }

        [Required(ErrorMessage = "Debe aclarar a que categoria pertenece")]
        public required string categoria { get; set; }

        [Required(ErrorMessage = "Debe ingresar el monto")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal monto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Total_Acumulado { get; set; }
    }
}
