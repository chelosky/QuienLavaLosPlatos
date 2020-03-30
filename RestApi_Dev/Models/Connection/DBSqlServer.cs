using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestApi_Dev.Models.Connection
{
    public class DBSqlServer : IDB
    {

        // Variable que se encarga de cambiar el tipo de entorno en el cual se ejecutara el sistema
        private string environmentConnection = "tutobackend";

        public DBSqlServer()
        {

        }

        /// <summary> 
        /// Metodo para proceso almacenados que retornar tuplas de la base de datos. 
        /// Su uso estará centralizara para consultas que utilicen SELECT para la obtención de información
        /// </summary>
        /// <param name="nameProceso"> Es el nombre del proceso almacenado.</param>
        /// <param name="parametros"> Es el conjunto de todos los atributos/variables almacenadas y su valor asociado.</param>
        /// <returns>
        /// Retorna un DataTable con los datos de la consulta, si ocurre un error retornará null
        /// </returns>
        public Object StoredProcedureQueryReturn(string nameProceso, List<(string, Object)> parametros)
        {
            SqlConnection _con = new SqlConnection();
            _con.ConnectionString = ConfigurationManager.ConnectionStrings[environmentConnection].ConnectionString;
            try
            {
                if (_con.State == ConnectionState.Closed)
                {
                    _con.Open();
                }
                SqlCommand cmd = new SqlCommand(nameProceso, _con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.Add(new SqlParameter(parametro.Item1, parametro.Item2));
                    }
                }
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                if (_con.State == ConnectionState.Open)
                {
                    _con.Close();
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary> 
        /// Metodo para proceso almacenados que realizactualizaciones en la base de datos. 
        /// Su uso estará centralizara para consultas que utilicen INSERT INTO, UPDATE y DELETE para actualizacion de información
        /// </summary>
        /// <param name="nameProceso"> Es el nombre del proceso almacenado.</param>
        /// <param name="parametros"> Es el conjunto de todos los atributos/variables almacenadas y su valor asociado.</param>
        /// <returns>
        /// Retorna true si el proceso almacenado fue ejecutado correctamente, en caso contrario retorna false
        /// </returns>
        public Object StoredProcedureQuery(string nameProceso, List<(string, Object)> parametros)
        {
            SqlConnection _con = new SqlConnection();
            _con.ConnectionString = ConfigurationManager.ConnectionStrings[environmentConnection].ConnectionString;
            try
            {
                if (_con.State == ConnectionState.Closed)
                {
                    _con.Open();
                }
                SqlCommand cmd = new SqlCommand(nameProceso, _con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.Add(new SqlParameter(parametro.Item1, parametro.Item2));
                    }
                }
                cmd.ExecuteNonQuery();
                if (_con.State == ConnectionState.Open)
                {
                    _con.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                if (_con.State == ConnectionState.Open)
                {
                    _con.Close();
                }
                return false;
            }
        }

    }


}