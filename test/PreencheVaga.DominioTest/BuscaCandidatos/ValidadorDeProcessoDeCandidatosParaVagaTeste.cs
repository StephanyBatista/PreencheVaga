using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;
using PreencheVaga.Dominio.BuscaCandidatos;
using PreencheVaga.Dominio.Vagas;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.DominioTest.BuscaCandidatos
{
    [TestClass]
    public class ValidadorDeProcessoDeCandidatosParaVagaTeste
    {
        private ValidadorDeProcessoDeCandidatosParaVaga _validador;
        private Mock<IRepositorioBase<Vaga>> _vagaRepositorio;
        private int _vagaId;
        
        [TestInitialize]
        public void SetUp()
        {
            _vagaId = 1;
            _vagaRepositorio = new Mock<IRepositorioBase<Vaga>>();
            _vagaRepositorio.Setup(repositorio => repositorio.ObterPorId(_vagaId))
                .Returns(FluentBuilder<Vaga>.New().Build);
            _validador = new ValidadorDeProcessoDeCandidatosParaVaga(_vagaRepositorio.Object);
        }

        [TestMethod]
        public void DeveValidarSeVagaExiste()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _validador.Validar(new FiltroDeCandidatoParaVagaDto())).Message;
            Assert.AreEqual("Vaga não existe", message);
        }
        
        [TestMethod]
        public void DeveValidarSeExistePeloMenosUmaTecnologiaComPeso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _validador.Validar(new FiltroDeCandidatoParaVagaDto{ VagaId = _vagaId})).Message;
            Assert.AreEqual("Deve existir pelo menos uma tecnologia com peso", message);
        }
        
        [TestMethod]
        public void NaoDeveValidarSePesoDaTecnologiaForMenoQueUm()
        {
            var pesoDaTecnologia = new PesoDaTecnologiaParaVagaDto {Peso = 0, TecnologiaId = 3};
            var model = new FiltroDeCandidatoParaVagaDto{ VagaId = 1, PesosDasTecnologias = new List<PesoDaTecnologiaParaVagaDto>(){pesoDaTecnologia}};
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _validador.Validar(model)).Message;
            Assert.AreEqual("Peso deve estar entre 1 a 5", message);
        }
        
        [TestMethod]
        public void NaoDeveValidarSePesoDaTecnologiaForMaiorQueCinco()
        {
            var pesoDaTecnologia = new PesoDaTecnologiaParaVagaDto {Peso = 6, TecnologiaId = 3};
            var model = new FiltroDeCandidatoParaVagaDto{ VagaId = 1, PesosDasTecnologias = new List<PesoDaTecnologiaParaVagaDto>(){pesoDaTecnologia}};
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _validador.Validar(model)).Message;
            Assert.AreEqual("Peso deve estar entre 1 a 5", message);
        }
    }
}