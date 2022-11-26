using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace CapaDatos
{
    public class CDEntidadDelito
    {
        private int dIddelito;
        private string ddelito, dgravedad_del_delito;

        public CDEntidadDelito() {

        }
       
        public CDEntidadDelito(int pIddelito, string pdelito, string pgravedad_del_delito)
        {
            dIddelito = pIddelito;
            dgravedad_del_delito = pgravedad_del_delito;
    
            }
        #region metodos get y set
        public int IdDelito
        {
            get { return dIddelito; }
            set { dIddelito = value; }
        }
        public string delito
        {
            get { return ddelito; }
            set { ddelito = value; }
        }
        public string gravedad_del_delito
        {
            get { return dgravedad_del_delito; }
            set { dgravedad_del_delito = value; }
        }
        #endregion

        //método para insertar un nuevo Suplidor. Recibirá el objeto objSuplidor como parámetro
        public string Insertar(CDEntidadDelito objCDEntidadDelito)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexión con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = SIGEMPConexion.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este caso SuplidorInsertar
                SqlCommand micomando = new SqlCommand("DelitoInsertar", sqlCon);
                sqlCon.Open(); //Abro la conexión
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                /*Envío los parámetros al procedimiento almacenado.
                - Los nombres que aparece con el signo @ delante son los parámetros que hemos
                creado en el procedimiento almacenado de la base de datos y debemos escribirlos tal cual
                aparecen en dicho procedimiento almacenado (respetar mayúsculas y mnúsculas).
                - Los nombres que aparecen al lado son las propiedades del objeto objSuplidor que se pasará
                como parámetro con los valores deseados. Puede usarse como lo declaramos en la clase
                (usando el prefijo ( d ), por ejemplo: dSuplidor, o bien , hacerlo como se declaran en los métodos Get y
                Set.
                */
                micomando.Parameters.AddWithValue("@pdelito", objCDEntidadDelito.delito);
                micomando.Parameters.AddWithValue("@pgravedad_del_delito", objCDEntidadDelito.gravedad_del_delito);
                //hasta aquí el pase de parámetros
                /*Ejecuto la instrucción. Si se devuelve el valor 1 significa que todo funcionó correctamente de lo
                * contrario se devuelve el mensaje indicando que fue incorrecto.
                */
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente!" :
                "No se pudo insertar correctamente los nuevos datos!";
            }
            catch (Exception ex) //Si ocurre algún error se captura y se muestra el mensaje
            {
                mensaje = ex.Message;
            }
            finally
            {
                if(sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }
        public string Actualizar(CDEntidadDelito objCDEntidadDelito)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexión con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = SIGEMPConexion.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este caso SuplidorInsertar
                SqlCommand micomando = new SqlCommand("DelitoActualizar", sqlCon);
                sqlCon.Open(); //Abro la conexión
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pId_delito", objCDEntidadDelito.delito);
                micomando.Parameters.AddWithValue("@pdelito", objCDEntidadDelito.delito);
                micomando.Parameters.AddWithValue("@pgravedad_del_delito", objCDEntidadDelito.gravedad_del_delito);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Actualización de datos completada correctamente!" :
                "No se pudo actualizar correctamente los nuevos datos!";
            }
            catch (Exception ex) //Si ocurre algún error se captura y se muestra el mensaje
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }
        //Método para consultar datos filtrados de la tabla. Se recibe el valor del parámetro
        public DataTable Consultar(String objCDEntidadDelito)
        {
            DataTable dt = new DataTable(); //Se Crea DataTable que tomará los datos de los Suplidores
            SqlDataReader leerDatos; //Creamos el DataReader
            string mensaje = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); //Establecer el comando
                sqlCmd.Connection = new SIGEMPConexion().dbconexion; //Conexión que va a usar el comando
                sqlCmd.Connection.Open(); //Se abre la conexión
                sqlCmd.CommandText = "DelitoConsultar"; //Nombre del Proc. Almacenado a usar
                sqlCmd.CommandType = CommandType.StoredProcedure; //Se trata de un proc. almacenado
                sqlCmd.Parameters.AddWithValue("@pvalor", objCDEntidadDelito); //Se pasa el valor a buscar
                leerDatos = sqlCmd.ExecuteReader(); //Llenamos el SqlDataReader con los datos resultantes
                dt.Load(leerDatos); //Se cargan los registros devueltos al DataTable
                sqlCmd.Connection.Close(); //Se cierra la conexión
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                dt = null; //Si ocurre algun error se anula el DataTable
            }
            return dt; ////Se retorna el DataTable segun lo ocurrido arriba
        } //Fin del método MostrarConFiltro
    }
}
