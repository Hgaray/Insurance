namespace InsuranceAppi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InsuranceContext : DbContext
    {
        public InsuranceContext()
            : base("name=InsuranceContext")
        {
        }

        public virtual DbSet<ClientePoliza> ClientePoliza { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Poliza> Poliza { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
        }
    }
}
