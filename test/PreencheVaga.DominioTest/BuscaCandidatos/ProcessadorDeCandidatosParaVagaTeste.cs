using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;
using PreencheVaga.Dominio.BuscaCandidatos;
using PreencheVaga.Dominio.Candidatos;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.DominioTest.BuscaCandidatos
{
    [TestClass]
    public class ProcessadorDeCandidatosParaVagaTeste
    {
        private Mock<IRepositorioBase<Candidato>> _candidatoRepositorio;
        private ProcessadorDeCandidatosParaVaga _processador;
        private Candidato _candidadoVencedor;
        private Candidato _candidadoSegundoColocado;
        private Candidato _candidadoTerceiroColocado;
        private Tecnologia _tecnologiaUm;
        private Tecnologia _tecnologiaDois;
        private Tecnologia _tecnologiaTres;
        private FiltroDeCandidatoParaVagaDto _filtroDeCandidatoParaVaga;

        [TestInitialize]
        public void SetUp()
        {
            _candidatoRepositorio = new Mock<IRepositorioBase<Candidato>>();

            _tecnologiaUm = FluentBuilder<Tecnologia>.New().With(tecnologia => tecnologia.Id, 1).Build();
            _tecnologiaDois = FluentBuilder<Tecnologia>.New().With(tecnologia => tecnologia.Id, 2).Build();
            _tecnologiaTres = FluentBuilder<Tecnologia>.New().With(tecnologia => tecnologia.Id, 3).Build();
            
            _candidadoSegundoColocado = FluentBuilder<Candidato>.New()
                .With(candidato => candidato.Nome, "Segundo Colocado")
                .With(candidato => candidato.TecnologiasQueConhece, new List<Tecnologia>{_tecnologiaTres})
                .Build();
            _candidadoTerceiroColocado = FluentBuilder<Candidato>.New()
                .With(candidato => candidato.Nome, "Terceiro Colocado")
                .With(candidato => candidato.TecnologiasQueConhece, new List<Tecnologia>{_tecnologiaDois})
                .Build();
            _candidadoVencedor = FluentBuilder<Candidato>.New()
                .With(candidato => candidato.Nome, "Vencedor")
                .With(candidato => candidato.TecnologiasQueConhece, new List<Tecnologia>{_tecnologiaUm, _tecnologiaTres})
                .Build();
            
            _candidatoRepositorio
                .Setup(repositorio => repositorio.ObterTodos())
                .Returns(new List<Candidato> { _candidadoVencedor, _candidadoSegundoColocado, _candidadoTerceiroColocado});
            
            _processador = new ProcessadorDeCandidatosParaVaga(_candidatoRepositorio.Object);
            
            var pesoDaTecnologiaUm = new PesoDaTecnologiaParaVagaDto { TecnologiaId = _tecnologiaUm.Id, Peso = 3};
            var pesoDaTecnologiaDois = new PesoDaTecnologiaParaVagaDto { TecnologiaId = _tecnologiaDois.Id, Peso = 2};
            var pesoDaTecnologiaTres = new PesoDaTecnologiaParaVagaDto { TecnologiaId = _tecnologiaTres.Id, Peso = 4};
            var pesosDasTecnologias = new List<PesoDaTecnologiaParaVagaDto> { pesoDaTecnologiaUm, pesoDaTecnologiaDois, pesoDaTecnologiaTres };
            _filtroDeCandidatoParaVaga = new FiltroDeCandidatoParaVagaDto { VagaId = 5, PesosDasTecnologias = pesosDasTecnologias };
        }

        [TestMethod]
        public void DeveProcessarCandidatosParaVagaComBaseNoPesoDaTecnologia()
        {
            const int pontuacaoEsperadaParaOVencedor = 7;
            

            var candidatosProcessados = _processador.Processar(_filtroDeCandidatoParaVaga);
            
            Assert.AreEqual(_candidadoVencedor.Nome, candidatosProcessados[0].NomeDoCandidato);
            Assert.AreEqual(pontuacaoEsperadaParaOVencedor, candidatosProcessados[0].Pontuacao);
        }
        
        [TestMethod]
        public void NaoDeveRetornarCandidatosQueNaoTiveramPontuacaoNoProcessamento()
        {
            var candidatoSemPontuacao = FluentBuilder<Candidato>.New().With(candidato => candidato.Nome, "Sem Pontuacao").Build();
            _candidatoRepositorio
                .Setup(repositorio => repositorio.ObterTodos())
                .Returns(new List<Candidato> { _candidadoVencedor, _candidadoSegundoColocado, _candidadoTerceiroColocado, candidatoSemPontuacao});

            var candidatosProcessados = _processador.Processar(_filtroDeCandidatoParaVaga);
            
            Assert.IsFalse(candidatosProcessados.Any(candidato => candidato.NomeDoCandidato == candidatoSemPontuacao.Nome));
        }
    }
}