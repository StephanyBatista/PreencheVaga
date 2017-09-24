using System.Linq;
using PreencheVaga.Dominio.Vagas;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.BuscaCandidatos
{
    public interface IValidadorDeProcessoDeCandidatosParaVaga
    {
        void Validar(FiltroDeCandidatoParaVagaDto model);
    }
    
    public class ValidadorDeProcessoDeCandidatosParaVaga : IValidadorDeProcessoDeCandidatosParaVaga
    {
        private readonly IRepositorioBase<Vaga> _vagaRepositorio;

        public ValidadorDeProcessoDeCandidatosParaVaga(IRepositorioBase<Vaga> vagaRepositorio)
        {
            _vagaRepositorio = vagaRepositorio;
        }

        public void Validar(FiltroDeCandidatoParaVagaDto model)
        {
            var vaga = _vagaRepositorio.ObterPorId(model.VagaId);
            
            ExcecaoDeDominio.Quando(vaga == null, "Vaga não existe");
            ExcecaoDeDominio.Quando(model.PesosDasTecnologias == null || !model.PesosDasTecnologias.Any(), "Deve existir pelo menos uma tecnologia com peso");
            ExcecaoDeDominio.Quando(model.PesosDasTecnologias.Exists(pesoDaTecnologia => pesoDaTecnologia.Peso < 1 || pesoDaTecnologia.Peso > 5), "Peso deve estar entre 1 a 5");
        }
    }
}