using PreencheVaga.Dominio._Base;

namespace PreencheVaga.Dominio.Vagas
{
    public class ArmazenadorDeVaga
    {
        private readonly IRepositorioBase<Vaga> _vagaRepositorio;

        public ArmazenadorDeVaga(IRepositorioBase<Vaga> vagaRepositorio)
        {
            _vagaRepositorio = vagaRepositorio;
        }

        public void Salvar(VagaDto vagaDto)
        {
            if (vagaDto.Id == 0)
            {
                var vaga = new Vaga(vagaDto.Nome, vagaDto.Descricao);
                _vagaRepositorio.Adicionar(vaga);
            }
            else
            {
                var vagaSalva = _vagaRepositorio.ObterPorId(vagaDto.Id);
                vagaSalva.AlterarNomeEDescricao(vagaDto.Nome, vagaDto.Descricao);
            }
        }
    }
}