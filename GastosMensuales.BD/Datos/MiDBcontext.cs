using GastosMensuales.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.BD.Datos
{
    public class MiDBcontext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet <Ingreso> Ingresos { get; set; }
        public DbSet<GastoFijo> GastosFijos { get; set; }
        public DbSet<GastoDiario> GastosDiarios { get; set; }



        public MiDBcontext(DbContextOptions options) : base(options)
        {
                
        }
    }
}
