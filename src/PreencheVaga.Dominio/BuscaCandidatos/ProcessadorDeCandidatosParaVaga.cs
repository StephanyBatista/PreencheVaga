using System.Collections.Generic;
using System.Linq;
using PreencheVaga.Dominio.Candidatos;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.BuscaCandidatos
{
    public class ProcessadorDeCandidatosParaVaga
    {
        private readonly IRepositorioBase<Candidato> _candidatoRepositorio;
        private readonly IValidadorDeProcessoDeCandidatosParaVaga _validadorDeProcessoDeCandidatosParaVaga;

        public ProcessadorDeCandidatosParaVaga(IRepositorioBase<Candidato> candidatoRepositorio, 
            IValidadorDeProcessoDeCandidatosParaVaga validadorDeProcessoDeCandidatosParaVaga)
        {
            _candidatoRepositorio = candidatoRepositorio;
            _validadorDeProcessoDeCandidatosParaVaga = validadorDeProcessoDeCandidatosParaVaga;
        }

        public List<CandidatoProcessado> Processar(FiltroDeCandidatoParaVagaDto model)
        {
            _validadorDeProcessoDeCandidatosParaVaga.Validar(model);
            
            var candidatos = _candidatoRepositorio.ObterTodos();
            var candidatosProcessados = new List<CandidatoProcessado>();
            
            foreach (var candidato in candidatos)
            {
                var pontuacao = model.PesosDasTecnologias
                    .Where(pesosDasTecnologia => candidato.TecnologiasQueConhece.Any(tecnologia => tecnologia.Id == pesosDasTecnologia.TecnologiaId))
                    .Sum(pesosDasTecnologia => pesosDasTecnologia.Peso);

                if(pontuacao > 0)
                    candidatosProcessados.Add(new CandidatoProcessado { NomeDoCandidato = candidato.Nome, Pontuacao = pontuacao});
            }

            return candidatosProcessados.OrderByDescending(ordem => ordem.Pontuacao).ToList();
        }
    }
}