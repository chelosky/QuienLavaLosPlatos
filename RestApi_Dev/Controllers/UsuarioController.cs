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
    public class UsuarioController : ApiController
    {
        [Route("Api/Usuario/ObtenerUsuarios")]
        public IHttpActionResult GetObtenerUsuarios()
        {
            List<UsuarioModel> ls = UsuarioModel.ObtenerTodosLosUsuarios();
            if (ls != null)
            {
                return Json(new { status = true, data = ls });
            }
            else
            {
                return Json(new { status = false });
            }
        }

        [Route("Api/Usuario/ObtenerUsuarioPorID")]
        public IHttpActionResult PostObtenerUsuarioPorId(UsuarioModel user)
        {
            if (user != null && user.id > 0)
            {
                UsuarioModel usr = UsuarioModel.ObtenerUsuarioPorId(user.id);
                if (usr != null)
                {
                    return Json(new { status = true, data = usr });
                }
                return Json(new { status = false, info = "Usuario no existe" });
            } else
            {
                return Json(new { status = false, info = "Datos erroneos" });
            }
        }

        [Route("Api/EJEMPLO")]
        public IHttpActionResult GetEjemplo()
        {
            return Json(new { status = false, info = "EJEMPLO" });
        }

    }
}
