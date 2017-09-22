namespace PreencheVaga.Dominio.Vagas
{
    public class Vaga
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Vaga(string nome, string descricao)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(descricao), "Descrição é obrigatório");
            
            Nome = nome;
            Descricao = descricao;
        }

    }
}