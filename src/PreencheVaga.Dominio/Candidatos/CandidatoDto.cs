using System.Collections.Generic;

namespace PreencheVaga.Dominio.Candidatos
{
    public class CandidatoDto
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal PretensaoSalarial { get; set; }
        public List<int> TecnologiasQueConhece { get; set; }
    }
}