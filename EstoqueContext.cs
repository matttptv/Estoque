using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estoque.Models;

namespace Estoque.Data
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext (DbContextOptions<EstoqueContext> options)
            : base(options)
        {
        }

        public DbSet<Estoque.Models.Produto> Produto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define a precisão e escala para o campo Price (ex: até 18 dígitos, 2 casas decimais)
            modelBuilder.Entity<Estoque.Models.Produto>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
