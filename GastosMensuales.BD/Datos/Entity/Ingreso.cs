using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.BD.Datos.Entity
{
    public class Ingreso : EntityBase
    {

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }



        [Column(TypeName = "decimal(10, 2)")]
        public decimal Sueldo   { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Sobrante { get; set; }

        [Required(ErrorMessage =("No ingreso ningun valor"))]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Total { get; set; }

        
    }
}
