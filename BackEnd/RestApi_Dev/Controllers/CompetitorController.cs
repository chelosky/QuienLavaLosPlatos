using RestApi_Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestApi_Dev.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompetitorController : ApiController
    {
        [Route("Api/Competitor/Todos")]
        public IHttpActionResult GetObtenerCompetitors()
        {
            List<CompetitorModel> ls = CompetitorModel.ObtenerTodos();
            if (ls != null)
            {
                return Json(new { status = true, data = ls });
            }
            else
            {
                return Json(new { status = false , info = "Error al intentar obtener a los competidores"});
            }
        }

        [Route("Api/Competitor/Ganador")]
        public IHttpActionResult PostActualizarCuerpo(CompetitorModel ganador)
        {
            if (ganador != null)
            {
                if (CompetitorModel.ActualizarGanador(ganador.id))
                {
                    return Json(new { status = true, info = "Ganador Registrado" });
                }
                else
                {
                    return Json(new { status = false, info = "Ha ocurrido un problema al ingresar al ganador" });
                }
            }
            else
            {
                return Json(new { status = false, info = "Los datos enviados son incorrectos" });
            }
        }

        [Route("Api/Competitor/GanadorAnterior")]
        public IHttpActionResult GetObtenerGanadorAnterior()
        {
            CompetitorModel ls = CompetitorModel.ObtenerGanadorAnterior();
            if (ls != null)
            {
                return Json(new { status = true, data = ls });
            }
            else
            {
                return Json(new { status = false, info = "Error al obtener ganador anterior" });
            }
        }

        [Route("Api/Competitor/Reiniciar")]
        public IHttpActionResult PostReiniciarGanador()
        {
            if (CompetitorModel.ReiniciarGanador())
            {
                return Json(new { status = true, info = "Reiniciar Registrado" });
            }
            else
            {
                return Json(new { status = false, info = "Ha ocurrido un problema al ingresar al reiniciar" });
            }   
        }
    }
}
