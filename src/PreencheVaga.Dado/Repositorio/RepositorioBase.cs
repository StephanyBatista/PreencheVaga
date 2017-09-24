using System.Collections.Generic;
using System.Linq;
using PreencheVaga.Dado.Context;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dado.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : Entidade
    {
        private readonly ApplicationDbContext _context;

        public RepositorioBase(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public T ObterPorId(int id)
        {
            return _context.Set<T>().FirstOrDefault(entidade => entidade.Id == id);
        }

        public List<T> ObterTodos()
        {
            return _context.Set<T>().ToList();
        }

        public void Adicionar(T entidade)
        {
            _context.Set<T>().Add(entidade);
        }
    }
}