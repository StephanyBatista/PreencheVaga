using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.UI.Controllers
{
    [Route("api/tecnologia/{id?}")]
    public class TecnologiaController : Controller
    {
        private readonly IRepositorioBase<Tecnologia> _tecnologiaRepositorio;
        private readonly ArmazenadorDeTecnologia _armazenadorDeTecnologia;

        public TecnologiaController(IRepositorioBase<Tecnologia> tecnologiaRepositorio, ArmazenadorDeTecnologia armazenadorDeTecnologia)
        {
            _tecnologiaRepositorio = tecnologiaRepositorio;
            _armazenadorDeTecnologia = armazenadorDeTecnologia;
        }
        
        [HttpGet]
        public JsonResult Get(int? id)
        {
            return id.HasValue ? 
                Json(_tecnologiaRepositorio.ObterPorId(id.Value)) : 
                Json(_tecnologiaRepositorio.ObterTodos());
        }

        [HttpPost]
        public JsonResult Post([FromBody]TecnologiaDto model)
        {
            _armazenadorDeTecnologia.Salvar(model);
            return Json(new {sucesso = true});
        }
    }
}