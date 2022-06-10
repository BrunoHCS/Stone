using ApiBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiBank.Infrastructure.Persistence
{
    public class ApiBankDbContext : DbContext
    {
        public ApiBankDbContext(DbContextOptions<ApiBankDbContext> options) : base(options)
        {

        }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Extrato> Extratos { get; set; }
        public DbSet<Saque> Saques { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaCorrente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Deposito>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Extrato>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Saque>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Transferencia>()
                .HasKey(t => t.Id);
        }
    }
}
