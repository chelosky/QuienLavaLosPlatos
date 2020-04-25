using RestApi_Dev.Models.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace RestApi_Dev.Models
{
    public class CompetitorModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string foto { get; set; }

        public static CompetitorModel ObtenerGanadorAnterior()
        {
            try
            {
                DataTable dt = (DataTable)DB.StoredProcedureQueryReturn("GetPreviousChosen", null);
                if(dt != null && dt.Rows.Count == 1)
                {
                    CompetitorModel competitor = new CompetitorModel();
                    competitor.id = Convert.ToInt32(dt.Rows[0]["idCompetitor"]);
                    competitor.nombre = dt.Rows[0]["nombreCompetitor"].ToString();
                    competitor.foto = dt.Rows[0]["urlImageCompetitor"].ToString();
                    return competitor;
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static List<CompetitorModel> ObtenerTodos()
        {
            try
            {
                //List<(string, object)> parametros = new List<(string, object)> { ("@codigo", codigo) };
                DataTable dt = (DataTable)DB.StoredProcedureQueryReturn("GetAll", null);
                if (dt != null)
                {
                    List<CompetitorModel> listado = new List<CompetitorModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CompetitorModel competitor = new CompetitorModel();
                        competitor.id = Convert.ToInt32(dt.Rows[i]["idCompetitor"]);
                        competitor.nombre = dt.Rows[i]["nombreCompetitor"].ToString();
                        competitor.foto = dt.Rows[i]["urlImageCompetitor"].ToString();
                        listado.Add(competitor);
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

        public static bool ActualizarGanador(int id)
        {
            List<(string, object)> parametros = new List<(string, object)> { 
                ("@idcompetitor", id)
            };
            return (bool)DB.StoredProcedureQuery("NewChosen", parametros);
        }

        public static bool ReiniciarGanador()
        {
            return (bool)DB.StoredProcedureQuery("ResetCompetitor", null);
        }
    }
}