using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.Vagas
{
    public class Vaga : Entidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        
        public Vaga() {}
        
        public Vaga(string nome, string descricao)
        {
            Validar(nome, descricao);

            Nome = nome;
            Descricao = descricao;
        }

        private static void Validar(string nome, string descricao)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(descricao), "Descrição é obrigatório");
        }

        public void AlterarNomeEDescricao(string nome, string descricao)
        {
            Validar(nome, descricao);
            
            Nome = nome;
            Descricao = descricao;
        }
    }
}