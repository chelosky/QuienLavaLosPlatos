using RestApi_Dev.Models.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RestApi_Dev.Models
{
    public class UsuarioModel
    {
        #region Atributos Usuario
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        #endregion

        #region Metodos Usuario

        public static UsuarioModel ObtenerUsuarioPorId(int id)
        {
            try
            {
                List<(string, object)> parametros = new List<(string, object)> { 
                    ("@idusuario", id)
                };
                DataTable dt = (DataTable)DB.StoredProcedureQueryReturn("ObtenerInfoUsuario", parametros);
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        UsuarioModel user = new UsuarioModel();
                        user.id = Convert.ToInt32(dt.Rows[0]["id"]);
                        user.nombre = dt.Rows[0]["nombre"].ToString();
                        user.descripcion = dt.Rows[0]["descripcion"].ToString();
                        return user;
                    }
                }
                return null;
            }catch(Exception e)
            {
                return null;
            }
        }

        public static List<UsuarioModel> ObtenerTodosLosUsuarios()
        {
            try
            {
                DataTable dt = (DataTable)DB.StoredProcedureQueryReturn("ObtenerUsuarios", null);
                if (dt != null)
                {
                    List<UsuarioModel> listado = new List<UsuarioModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        UsuarioModel ejemplo = new UsuarioModel();
                        ejemplo.id = Convert.ToInt32(dt.Rows[i]["id"]);
                        ejemplo.nombre = dt.Rows[i]["nombre"].ToString();
                        ejemplo.descripcion = dt.Rows[i]["descripcion"].ToString();
                        listado.Add(ejemplo);
                    }
                    return listado;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}