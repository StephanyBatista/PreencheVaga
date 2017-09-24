using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.Tecnologias
{
    public class Tecnologia : Entidade
    {
        public string Nome { get; private set; }

        private Tecnologia() {}

        public Tecnologia(string nome)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            
            Nome = nome;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}