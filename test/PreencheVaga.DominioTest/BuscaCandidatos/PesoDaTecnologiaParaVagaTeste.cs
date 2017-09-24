using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;
using PreencheVaga.Dominio.BuscaCandidatos;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.DominioTest.BuscaCandidatos
{
    [TestClass]
    public class PesoDaTecnologiaParaVagaTeste
    {
        [TestMethod]
        public void DeveCriarObjeto()
        {
            const int peso = 5;
            var tecnologia = FluentBuilder<Tecnologia>.New().Build();
            
            var pesoDaTecnologiaParaVaga = new PesoDaTecnologiaParaVaga(peso, tecnologia);
            
            Assert.AreEqual(peso, pesoDaTecnologiaParaVaga.Peso);
            Assert.AreEqual(tecnologia, pesoDaTecnologiaParaVaga.Tecnologia);
        }

        [TestMethod]
        public void NaoDeveCriarObjetoComPesoMenorQueUm()
        {
            var tecnologia = FluentBuilder<Tecnologia>.New().Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new PesoDaTecnologiaParaVaga(0, tecnologia)).Message;
            Assert.AreEqual("Peso deve estar entre 1 e 5", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarObjetoComPesoMaiorQueCinco()
        {
            var tecnologia = FluentBuilder<Tecnologia>.New().Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new PesoDaTecnologiaParaVaga(6, tecnologia)).Message;
            Assert.AreEqual("Peso deve estar entre 1 e 5", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarObjetoSemTecnologia()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new PesoDaTecnologiaParaVaga(3, null)).Message;
            Assert.AreEqual("Tecnologia é obrigatório", message);
        }
    }
}