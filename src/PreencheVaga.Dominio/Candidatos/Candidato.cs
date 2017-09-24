using System.Collections.Generic;
using System.Linq;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.Candidatos
{
    public class Candidato : Entidade
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public decimal PretensaoSalarial { get; private set; }
        public virtual ICollection<Tecnologia> TecnologiasQueConhece { get; private set; }
        
        public Candidato() {}        
        
        public Candidato(string nome, int idade, decimal pretensaoSalarial, List<Tecnologia> tecnologiasQueConhece)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(idade < 18, "Idade inválida, candidato deve ter idade igual ou maior que 18 anos");
            ExcecaoDeDominio.Quando(idade > 99, "Pela idade do candidato é possível estar inválido");
            ExcecaoDeDominio.Quando(pretensaoSalarial < 937, "Pretensão salarial não pode ser menor que o salario mínimo");
            ExcecaoDeDominio.Quando(tecnologiasQueConhece == null || !tecnologiasQueConhece.Any(), "O candidato deve conhecer pelo menos uma tecnologia");
            
            Nome = nome;
            Idade = idade;
            PretensaoSalarial = pretensaoSalarial;
            TecnologiasQueConhece = tecnologiasQueConhece;
        }
    }
}