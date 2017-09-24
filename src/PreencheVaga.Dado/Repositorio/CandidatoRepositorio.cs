using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PreencheVaga.Dado.Context;
using PreencheVaga.Dominio.Candidatos;

namespace PreencheVaga.Dado.Repositorio
{
    public class CandidatoRepositorio : RepositorioBase<Candidato>
    {
        public CandidatoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override List<Candidato> ObterTodos()
        {
            return Context.Set<Candidato>().Include(candidato => candidato.TecnologiasQueConhece).ToList();
        }
    }
}