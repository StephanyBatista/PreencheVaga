using System.Linq;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.Candidatos
{
    public class ArmazenadorDeCandidato
    {
        private readonly IRepositorioBase<Candidato> _candidatoRepositorio;
        private readonly IRepositorioBase<Tecnologia> _tecnologiaRepositorio;

        public ArmazenadorDeCandidato(IRepositorioBase<Candidato> candidatoRepositorio, IRepositorioBase<Tecnologia> tecnologiaRepositorio)
        {
            _candidatoRepositorio = candidatoRepositorio;
            _tecnologiaRepositorio = tecnologiaRepositorio;
        }

        public void Salvar(CandidatoDto candidatoDto)
        {
            var tecnologias = candidatoDto.TecnologiasQueConhece.Select(tecnologiaId => _tecnologiaRepositorio.ObterPorId(tecnologiaId)).ToList();

            var candidato = new Candidato(candidatoDto.Nome, candidatoDto.Idade, candidatoDto.PretensaoSalarial, tecnologias);
            
            _candidatoRepositorio.Adicionar(candidato);
        }
    }
}