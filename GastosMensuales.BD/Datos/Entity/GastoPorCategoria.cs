using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.BD.Datos.Entity
{
    public class GastoPorCategoria
    { 
        public int GastoDiarioId {get; set;}
        public GastoDiario? GastoDiario {get; set;}


        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public required string Categoria { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Column(TypeName = "decimal(10, 2)")]
        public required decimal Monto_Total { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public required int Porcentaje { get; set; }
    }
}
