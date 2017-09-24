using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.Tecnologias
{
    public class ArmazenadorDeTecnologia
    {
        private readonly IRepositorioBase<Tecnologia> _tecnologiaRepositorio;

        public ArmazenadorDeTecnologia(IRepositorioBase<Tecnologia> tecnologiaRepositorio)
        {
            _tecnologiaRepositorio = tecnologiaRepositorio;
        }

        public void Salvar(TecnologiaDto dto)
        {
            if(dto.Id == 0)
                _tecnologiaRepositorio.Adicionar(new Tecnologia(dto.Nome));
            else
            {
                var tecnologiaSalva = _tecnologiaRepositorio.ObterPorId(dto.Id);
                tecnologiaSalva.AlterarNome(dto.Nome);
            }
        }
    }
}