using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using CapaDatos;
using System.Net.NetworkInformation;

namespace CapaDetenciones
{
    public class CDE_delito
    {
        //Preparamos los datos para insertar un nuevo Suplidor.A los parametros recibidos les pongo el prefijo p
            public static string Insertar(int pidDelito, string pdelito, string pgravedad_del_delito)
        {
            CDEntidadDelito objEntidadDelito = new CDEntidadDelito();
            objEntidadDelito.IdDelito = pidDelito;
            objEntidadDelito.delito = pdelito;
            objEntidadDelito.gravedad_del_delito = pgravedad_del_delito;
   
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objEntidadDelito.Insertar(objEntidadDelito);
        } //Fin del método Insertar

          //Preparamos los datos para insertar un nuevo Suplidor.A los parametros recibidos les pongo el prefijo p
        public static string Actualizar(int pidDelito, string pdelito, string pgravedad_del_delito)
        {
            CDEntidadDelito objEntidadDelito = new CDEntidadDelito();
            objEntidadDelito.IdDelito = pidDelito;
            objEntidadDelito.delito = pdelito;
            objEntidadDelito.gravedad_del_delito = pgravedad_del_delito;

            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objEntidadDelito.Actualizar(objEntidadDelito);
        } //Fin del método Actualizar

        //Método utilizado para obtener un DataTable con todos los datos de la tabla correspondiente
        public DataTable ObtenerDelito(string objCDEntidadDelito)
        {
            CDEntidadDelito objEntidadDelito = new CDEntidadDelito();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = objEntidadDelito.Consultar(objCDEntidadDelito); //El DataTable se llena con todos los datos devueltos
            return dt; //Se retorna el DataTable con los datos adquiridos
        }
    }
}
