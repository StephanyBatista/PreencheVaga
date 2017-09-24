using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;
using PreencheVaga.Dominio.Candidatos;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.DominioTest.Candidatos
{
    [TestClass]
    public class ArmazenadorDeCandidatoTeste
    {
        private Mock<IRepositorioBase<Candidato>> _candidatoRepositorio;
        private ArmazenadorDeCandidato _armazenador;
        private List<Tecnologia> _tecnologiasQueConhece;
        private Mock<IRepositorioBase<Tecnologia>> _tecnologiaRepositorio;

        [TestInitialize]
        public void SetUp()
        {
            _tecnologiasQueConhece = new List<Tecnologia>
            {
                FluentBuilder<Tecnologia>.New().With(tecnologia => tecnologia.Id, 1).Build(),
                FluentBuilder<Tecnologia>.New().With(tecnologia => tecnologia.Id, 2).Build()
            };
            
            _tecnologiaRepositorio = new Mock<IRepositorioBase<Tecnologia>>();
            _tecnologiaRepositorio.Setup(repositorio => repositorio.ObterPorId(_tecnologiasQueConhece[0].Id))
                .Returns(_tecnologiasQueConhece[0]);
            _tecnologiaRepositorio.Setup(repositorio => repositorio.ObterPorId(_tecnologiasQueConhece[1].Id))
                .Returns(_tecnologiasQueConhece[1]);
            
            _candidatoRepositorio = new Mock<IRepositorioBase<Candidato>>();
            
            _armazenador = new ArmazenadorDeCandidato(_candidatoRepositorio.Object, _tecnologiaRepositorio.Object);
        }

        [TestMethod]
        public void DeveAdicionarNovoCandidato()
        {
            var candidatoDto = new CandidatoDto
            {
                Nome = "Katia", 
                Idade = 30, 
                PretensaoSalarial = 5000, 
                TecnologiasQueConhece = _tecnologiasQueConhece.Select(tecnologia => tecnologia.Id).ToList()
            };

            _armazenador.Salvar(candidatoDto);
            
            _candidatoRepositorio.Verify(
                repositorio => repositorio.Adicionar(
                    It.Is<Candidato>(candidato => candidato.Nome == candidatoDto.Nome && 
                                                  candidato.TecnologiasQueConhece.Count == _tecnologiasQueConhece.Count)));
        }
    }
}