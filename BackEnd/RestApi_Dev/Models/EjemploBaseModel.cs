using RestApi_Dev.Models.Connection;
using System;
using System.Collections.Generic;
using System.Data;

namespace RestApi_Dev.Models
{
    public class EjemploBaseModel
    {
        public int identificador { get; set; }
        public string nombre { get; set; }

        public static List<EjemploBaseModel> ObtenerTodos()
        {
            try
            {
                //List<(string, object)> parametros = new List<(string, object)> { ("@codigo", codigo) };
                DataTable dt = (DataTable)DB.StoredProcedureQueryReturn("ObtieneTodasFuncionesSistema", null);
                if (dt != null)
                {
                    List<EjemploBaseModel> listado = new List<EjemploBaseModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EjemploBaseModel ejemplo = new EjemploBaseModel();
                        ejemplo.identificador = Convert.ToInt32(dt.Rows[i]["idFuncion"]);
                        ejemplo.nombre = dt.Rows[i]["nombreFuncion"].ToString();
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

        public static bool ActualizarEstado(int id, string estado)
        {
            List<(string, object)> parametros = new List<(string, object)> { ("@idfuncion", id), ("@estado", estado) };
            return (bool)DB.StoredProcedureQuery("ActualizarEstado", parametros);
        }
    }
}