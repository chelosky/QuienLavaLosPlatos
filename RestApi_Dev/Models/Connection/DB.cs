using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RestApi_Dev.Models.Connection
{
    class DB
    {
        // Variable estatica para utilizar la conexión de Sql Server
        public static IDB _DB = new DBSqlServer();

        /// <summary> 
        /// Metodo para proceso almacenados que retornar tuplas de la base de datos. 
        /// Su uso estará centralizara para consultas que utilicen SELECT para la obtención de información
        /// </summary>
        /// <param name="nameProceso"> Es el nombre del proceso almacenado.</param>
        /// <param name="parametros"> Es el conjunto de todos los atributos/variables almacenadas y su valor asociado.</param>
        /// <returns>
        /// Retorna un DataTable con los datos de la consulta, si ocurre un error retornará null
        /// </returns>
        public static Object StoredProcedureQueryReturn(string nameProceso, List<(string, Object)> parametros)
        {
            return _DB.StoredProcedureQueryReturn(nameProceso, parametros);
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
        public static Object StoredProcedureQuery(string nameProceso, List<(string, Object)> parametros)
        {
            return _DB.StoredProcedureQuery(nameProceso, parametros);
        }

    }
}