using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreencheVaga.Dominio;
using PreencheVaga.Dominio.Tecnologias;

namespace PreencheVaga.DominioTest.Tecnologias
{
    [TestClass]
    public class TecnologiaTeste
    {
        [TestMethod]
        public void DeveCriarTecnologia()
        {
            const string nomeEsperado = "NodeJs";
            
            var tecnologia = new Tecnologia(nomeEsperado);

            Assert.AreEqual(nomeEsperado, tecnologia.Nome);
        }

        [TestMethod]
        public void NaoDeveCriarTecnologiaComNomeVazio()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Tecnologia(string.Empty)).Message;
            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarTecnologiaComNomeNulo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Tecnologia(null)).Message;
            Assert.AreEqual("Nome é obrigatório", message);
        }
    }
}