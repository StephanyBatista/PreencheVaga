using Microsoft.AspNetCore.Mvc;
using PreencheVaga.Dominio.BuscaCandidatos;

namespace PreencheVaga.UI.Controllers
{
    [Route("api/preenchervaga")]
    public class PreencherVagaController : Controller
    {
        private readonly ProcessadorDeCandidatosParaVaga _processadorDeCandidatosParaVaga;

        public PreencherVagaController(ProcessadorDeCandidatosParaVaga processadorDeCandidatosParaVaga)
        {
            _processadorDeCandidatosParaVaga = processadorDeCandidatosParaVaga;
        }
        
        [HttpPost]
        public JsonResult Post([FromBody]FiltroDeCandidatoParaVagaDto model)
        {
            return Json(_processadorDeCandidatosParaVaga.Processar(model));
        }
    }
}