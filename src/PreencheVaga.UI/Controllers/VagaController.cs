using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio.Vagas;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.UI.Controllers
{
    [Route("api/vaga/{id?}")]
    public class VagaController : Controller
    {
        private readonly IRepositorioBase<Vaga> _vagaRepositorio;
        private readonly ArmazenadorDeVaga _armazenadorDeVaga;

        public VagaController(IRepositorioBase<Vaga> vagaRepositorio, ArmazenadorDeVaga armazenadorDeVaga)
        {
            _vagaRepositorio = vagaRepositorio;
            _armazenadorDeVaga = armazenadorDeVaga;
        }
        
        [HttpGet]
        public JsonResult Get(int? id)
        {
            return id.HasValue ? 
                Json(_vagaRepositorio.ObterPorId(id.Value)) : 
                Json(_vagaRepositorio.ObterTodos());
        }

        [HttpPost]
        public JsonResult Post([FromBody]VagaDto model)
        {
            _armazenadorDeVaga.Salvar(model);
            return Json(new {sucesso = true});
        }
    }
}