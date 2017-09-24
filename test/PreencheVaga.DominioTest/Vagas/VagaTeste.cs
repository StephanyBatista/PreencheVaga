using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;
using PreencheVaga.Dominio;
using PreencheVaga.Dominio.Vagas;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.DominioTest.Vagas
{
    [TestClass]
    public class VagaTeste
    {
        [TestMethod]
        public void DeveCriarVaga()
        {
            const string nomeEsperado = "Programador .Net";
            const string descricaoEsperada = "Desenvolver soluções em .Net e efetuar analises";
            var vaga = new Vaga(nomeEsperado, descricaoEsperada);

            Assert.AreEqual(nomeEsperado, vaga.Nome);
            Assert.AreEqual(descricaoEsperada, vaga.Descricao);
        }

        [TestMethod]
        public void NaoDeveCriarVagaComNomeVazio()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Vaga(string.Empty, "descrição qualquer")).Message;
            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarVagaComNomeNulo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Vaga(null, "descrição qualquer")).Message;
            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarVagaComDescricaoVazia()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Vaga("nome qualquer", string.Empty)).Message;
            Assert.AreEqual("Descrição é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarVagaComDescricaoNula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Vaga("nome qualquer", null)).Message;
            Assert.AreEqual("Descrição é obrigatório", message);
        }
        
        [TestMethod]
        public void DeveAlterarNomeEDescricao()
        {
            const string nomeEsperado = "Programador .Net";
            const string descricaoEsperada = "Desenvolver soluções em .Net e efetuar analises";
            var vaga = FluentBuilder<Vaga>.New().Build();

            vaga.AlterarNomeEDescricao(nomeEsperado, descricaoEsperada);
            
            Assert.AreEqual(nomeEsperado, vaga.Nome);
            Assert.AreEqual(descricaoEsperada, vaga.Descricao);
        }
        
        [TestMethod]
        public void NaoDeveAlterarVagaComNomeVazio()
        {
            var vaga = FluentBuilder<Vaga>.New().Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => vaga.AlterarNomeEDescricao(string.Empty, "descrição qualquer")).Message;
            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveAltearVagaComNomeNulo()
        {
            var vaga = FluentBuilder<Vaga>.New().Build();
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => vaga.AlterarNomeEDescricao(null, "descrição qualquer")).Message;
            Assert.AreEqual("Nome é obrigatório", message);
        }
        
        [TestMethod]
        public void NaoDeveAlterarVagaComDescricaoVazio()
        {
            var vaga = FluentBuilder<Vaga>.New().Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => vaga.AlterarNomeEDescricao("vaga qualquer", string.Empty)).Message;
            Assert.AreEqual("Descrição é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveAltearVagaComDescricaoNulo()
        {
            var vaga = FluentBuilder<Vaga>.New().Build();
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => vaga.AlterarNomeEDescricao("vaga qualquer", null)).Message;
            Assert.AreEqual("Descrição é obrigatório", message);
        }
    }
}