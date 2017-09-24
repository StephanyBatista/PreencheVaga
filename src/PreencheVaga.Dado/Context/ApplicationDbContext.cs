using Microsoft.EntityFrameworkCore;
using PreencheVaga.Dominio.Candidatos;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio.Vagas;

namespace PreencheVaga.Dado.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
    }
}