using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi_Dev.Models.Connection
{
    interface IDB
    {
        /// <summary> 
        /// Metodo para proceso almacenados que retornar tuplas de la base de datos. 
        /// Su uso estará centralizara para consultas que utilicen SELECT para la obtención de información
        /// </summary>
        Object StoredProcedureQueryReturn(string nameProceso, List<(string, Object)> parametros);

        /// <summary> 
        /// Metodo para proceso almacenados que realizactualizaciones en la base de datos. 
        /// Su uso estará centralizara para consultas que utilicen INSERT INTO, UPDATE y DELETE para actualizacion de información
        /// </summary>
        Object StoredProcedureQuery(string nameProceso, List<(string, Object)> parametros);
    }
}
