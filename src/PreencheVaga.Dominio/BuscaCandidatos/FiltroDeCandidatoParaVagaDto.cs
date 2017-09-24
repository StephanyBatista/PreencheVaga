using System.Collections.Generic;

namespace PreencheVaga.Dominio.BuscaCandidatos
{
    public class FiltroDeCandidatoParaVagaDto
    {
        public int VagaId { get; set; }
        public List<PesoDaTecnologiaParaVagaDto> PesosDasTecnologias { get; set; }
    }
}