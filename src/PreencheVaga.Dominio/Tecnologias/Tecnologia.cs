namespace PreencheVaga.Dominio.Tecnologias
{
    public class Tecnologia
    {
        public string Nome { get; private set; }

        public Tecnologia(string nome)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            
            Nome = nome;
        }
    }
}