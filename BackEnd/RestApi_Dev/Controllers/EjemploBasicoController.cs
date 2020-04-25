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
    public class EjemploBasicoController : ApiController
    {
        [Route("Api/Ejemplo/ObtenerAll")]
        public IHttpActionResult GetObtenerTodosLasFunciones()
        {
            List<EjemploBaseModel> ls = EjemploBaseModel.ObtenerTodos();
            if (ls != null)
            {
                return Json(new { status = true, data = ls });
            }
            else
            {
                return Json(new { status = false });
            }
        }

        [Route("Api/Ejemplo/ActualizarCuerpo")]
        public IHttpActionResult PostActualizarCuerpo(EjemploBaseModel ejemplo)
        {
            if (ejemplo != null)
            {
                if (EjemploBaseModel.ActualizarEstado(ejemplo.identificador, ejemplo.nombre))
                {
                    return Json(new { status = true, info = "El cuerpo ha sido actualizado con existo" });
                }
                else
                {
                    return Json(new { status = false, info = "Ha ocurrido un problema al intentar actualizar el cuerpo" });
                }
            }
            else
            {
                return Json(new { status = false, info = "Los datos enviados son incorrectos" });
            }
        }
    }
}
