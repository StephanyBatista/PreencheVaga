using System.Collections.Generic;
using System.Linq;
using PreencheVaga.Dado.Context;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dado.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : Entidade
    {
        protected readonly ApplicationDbContext Context;

        public RepositorioBase(ApplicationDbContext context)
        {
            Context = context;
        }
        
        public virtual T ObterPorId(int id)
        {
            return Context.Set<T>().FirstOrDefault(entidade => entidade.Id == id);
        }

        public virtual List<T> ObterTodos()
        {
            return Context.Set<T>().ToList();
        }

        public virtual void Adicionar(T entidade)
        {
            Context.Set<T>().Add(entidade);
        }
    }
}