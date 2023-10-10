using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PizzeriaNana.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<DettaglioOrdini> DettaglioOrdini { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordini>()
                .Property(e => e.Importo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Prodotti>()
                .Property(e => e.Costo)
                .HasPrecision(19, 4);
        }
    }
}
