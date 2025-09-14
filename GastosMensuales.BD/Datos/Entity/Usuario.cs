using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.BD.Datos.Entity
{
    public class Usuario : EntityBase
    {

        [Required(ErrorMessage ="Debe ingresar su nombre")]
        [MaxLength(45, ErrorMessage = "Demasiados Caracteres")]
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar su apellido")]
        [MaxLength(45, ErrorMessage ="Demasiados Caracteres")]
        public required string Apellido { get; set; }


      //  public List<Ingreso>? Ingresos { get; set; } = new List<Ingreso>();
        //public List<GastoFijo>? GastosFijos { get; set; } = new List<GastoFijo>();
        //public List<GastoDiario>? GastosDiarios { get; set; } = new List<GastoDiario>();
    }
}
