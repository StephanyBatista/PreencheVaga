using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.DominioTest.Tecnologias
{
    [TestClass]
    public class ArmazenadorDeTecnologiaTeste
    {
        private Mock<IRepositorioBase<Tecnologia>> _tecnologiaRepositorio;
        private ArmazenadorDeTecnologia _armazenador;

        [TestInitialize]
        public void SetUp()
        {
            _tecnologiaRepositorio = new Mock<IRepositorioBase<Tecnologia>>();
            _armazenador = new ArmazenadorDeTecnologia(_tecnologiaRepositorio.Object);
        }

        [TestMethod]
        public void DeveAdicionarNovaTecnologia()
        {
            var tecnologiaDto = new TecnologiaDto {Nome = "Node Js"};

            _armazenador.Salvar(tecnologiaDto);
            
            _tecnologiaRepositorio.Verify(repositorio => repositorio.Adicionar(It.Is<Tecnologia>(t => t.Nome == tecnologiaDto.Nome)));
        }
        
        [TestMethod]
        public void DeveAtualizarTecnologiaJaSalva()
        {
            var tecnologiaDto = new TecnologiaDto {Id = 1, Nome = "C#"};
            var tecnologia = FluentBuilder<Tecnologia>.New().Build();
            _tecnologiaRepositorio.Setup(repositorio => repositorio.ObterPorId(tecnologiaDto.Id)).Returns(tecnologia);

            _armazenador.Salvar(tecnologiaDto);
            
            Assert.AreEqual(tecnologiaDto.Nome, tecnologia.Nome);
        }
    }
}