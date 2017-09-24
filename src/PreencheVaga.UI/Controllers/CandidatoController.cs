using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PreencheVaga.Dominio.Candidatos;
using PreencheVaga.Dominio.Tecnologias;
using PreencheVaga.Dominio.Vagas;
using PreencheVaga.Dominio._Base;

namespace PreencheVaga.UI.Controllers
{
    [Route("api/candidato")]
    public class CandidatoController : Controller
    {
        private readonly ArmazenadorDeCandidato _armazenadorDeCandidato;

        public CandidatoController(ArmazenadorDeCandidato armazenadorDeCandidato)
        {
            _armazenadorDeCandidato = armazenadorDeCandidato;
        }
        
        [HttpPost]
        public JsonResult Post([FromBody]CandidatoDto model)
        {
            _armazenadorDeCandidato.Salvar(model);
            return Json(new {sucesso = true});
        }
    }
}