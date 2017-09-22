using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreencheVaga.Dominio;
using PreencheVaga.Dominio.Candidatos;
using PreencheVaga.Dominio.Tecnologias;

namespace PreencheVaga.DominioTest.Candidatos
{
    [TestClass]
    public class CandidatoTeste
    {
        private string _nomeEsperado;
        private int _idadeEsperada;
        private decimal _pretensaoSalarialEsperada;
        private Tecnologia[] _tecnologiasQueConheceEsperada;

        [TestInitialize]
        public void SetUp()
        {
            _nomeEsperado = "Katia";
            _idadeEsperada = 30;
            _pretensaoSalarialEsperada = 1600m;
            _tecnologiasQueConheceEsperada = new[] { new Tecnologia("NodeJs"), new Tecnologia("Java"), new Tecnologia(".Net") };
        }
        
        [TestMethod]
        public void DeveCriarCandidato()
        {
            var candidato = new Candidato(_nomeEsperado, _idadeEsperada, _pretensaoSalarialEsperada, _tecnologiasQueConheceEsperada.ToList());
            
            Assert.AreEqual(_nomeEsperado, candidato.Nome);
            Assert.AreEqual(_idadeEsperada, candidato.Idade);
            Assert.AreEqual(_pretensaoSalarialEsperada, candidato.PretensaoSalarial);
            CollectionAssert.AreEquivalent(_tecnologiasQueConheceEsperada, candidato.TecnologiasQueConhece);
        }

        [TestMethod]
        public void NaoDeveCriarCandidadoComNomeVazio()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Candidato(string.Empty, _idadeEsperada, _pretensaoSalarialEsperada, _tecnologiasQueConheceEsperada.ToList())).Message;
            
            Assert.AreEqual("Nome é obrigatório", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarCandidadoComNomeNulo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Candidato(null, _idadeEsperada, _pretensaoSalarialEsperada, _tecnologiasQueConheceEsperada.ToList())).Message;
            
            Assert.AreEqual("Nome é obrigatório", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarCandidadoComIdadeMenorQue18()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Candidato(_nomeEsperado, 17, _pretensaoSalarialEsperada, _tecnologiasQueConheceEsperada.ToList())).Message;
            
            Assert.AreEqual("Idade inválida, candidato deve ter idade igual ou maior que 18 anos", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarCandidadoComIdadeMaiorQue99()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Candidato(_nomeEsperado, 100, _pretensaoSalarialEsperada, _tecnologiasQueConheceEsperada.ToList())).Message;
            
            Assert.AreEqual("Pela idade do candidato é possível estar inválido", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarCandidadoComPretensaoSalarialMenorQueOSalarioMinimo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Candidato(_nomeEsperado, _idadeEsperada, 936, _tecnologiasQueConheceEsperada.ToList())).Message;
            
            Assert.AreEqual("Pretensão salarial não pode ser menor que o salario mínimo", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarCandidadoComTecnologiaQueConheceNula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Candidato(_nomeEsperado, _idadeEsperada, _pretensaoSalarialEsperada, null)).Message;
            
            Assert.AreEqual("O candidato deve conhecer pelo menos uma tecnologia", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarCandidadoComTecnologiaQueConheceVazia()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Candidato(_nomeEsperado, _idadeEsperada, _pretensaoSalarialEsperada, new List<Tecnologia>())).Message;
            
            Assert.AreEqual("O candidato deve conhecer pelo menos uma tecnologia", message);
        }
    }
}