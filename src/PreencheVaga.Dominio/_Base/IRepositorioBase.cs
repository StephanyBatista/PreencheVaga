using System.Collections.Generic;

namespace PreencheVaga.Dominio._Base
{
    public interface IRepositorioBase<T> where T : Entidade
    {
        T ObterPorId(int id);
        List<T> ObterTodos(); 
        void Adicionar(T entidade);
    }
}