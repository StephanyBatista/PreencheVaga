using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.BuscaCandidatos
{
    public class PesoDaTecnologiaParaVaga
    {
        public int Peso { get; private set; }
        public Tecnologia Tecnologia { get; private set; }
        
        public PesoDaTecnologiaParaVaga(int peso, Tecnologia tecnologia)
        {
            ExcecaoDeDominio.Quando(peso < 1 || peso > 5, "Peso deve estar entre 1 e 5");
            ExcecaoDeDominio.Quando(tecnologia == null, "Tecnologia é obrigatório");
            
            Peso = peso;
            Tecnologia = tecnologia;
        }
    }
}