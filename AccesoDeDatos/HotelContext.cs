using HotelDeCabañas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos
{
    public class HotelContext : DbContext
    {
        public DbSet<Cabaña> cabañas{ get; set; }
        public DbSet<Mantenimiento> mantenimientos { get; set; }
        public DbSet<TipoCabaña> tipos { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Configuracion> configuraciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"SERVER = (localDb)\MsSqlLocalDb;DATABASE = HoteleriaDB;Integrated Security = true");
        }
    }
}
