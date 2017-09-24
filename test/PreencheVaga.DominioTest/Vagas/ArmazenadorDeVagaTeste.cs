using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;
using PreencheVaga.Dominio.Vagas;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.DominioTest.Vagas
{
    [TestClass]
    public class ArmazenadorDeVagaTeste
    {
        private Mock<IRepositorioBase<Vaga>> _vagaRepositorio;
        private ArmazenadorDeVaga _armazenador;

        [TestInitialize]
        public void SetUp()
        {
            _vagaRepositorio = new Mock<IRepositorioBase<Vaga>>();
            _armazenador = new ArmazenadorDeVaga(_vagaRepositorio.Object);
        }
        
        [TestMethod]
        public void DeveAdicionarNovaVaga()
        {
            var vagaDto = new VagaDto {Nome = "Programador", Descricao = "Vaga para programador"};

            _armazenador.Salvar(vagaDto);
            
            _vagaRepositorio.Verify(
                repositorio => repositorio.Adicionar(It.Is<Vaga>(vaga => vaga.Nome == vagaDto.Nome && vaga.Descricao == vagaDto.Descricao)));
        }

        [TestMethod]
        public void DeveAtualizarVagaJaSalva()
        {
            var vagaDto = new VagaDto {Id = 1, Nome = "Analista", Descricao = "Vaga para analista"};
            var vaga = FluentBuilder<Vaga>.New().Build();
            _vagaRepositorio.Setup(repositorio => repositorio.ObterPorId(vagaDto.Id)).Returns(vaga);
            
            _armazenador.Salvar(vagaDto);
            
            Assert.AreEqual(vagaDto.Nome, vaga.Nome);
            Assert.AreEqual(vagaDto.Descricao, vaga.Descricao);
        }
    }
}