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
    public class CDEntidadPersonal
    {
        private int dIdcarnet_policial;
        private string dnumero_de_carnet, dnombre, dapellido, ddireccion, dtelefono, dmovil, dsexo, destado, dtipo_de_documento, ddocumento_de_identidad;
        public CDEntidadPersonal()
        {

        }
        public CDEntidadPersonal(int pIdcarnet_policial, string pnumero_de_carnet, string pnombre, string papellido, string pdireccion, string ptelefono, string pmovil, string psexo, string pestado, string ptipo_de_documento, string pdocumento_de_identidad)
        {
            dIdcarnet_policial = pIdcarnet_policial;
            dnumero_de_carnet = pnumero_de_carnet;
            dnombre = pnombre;
            dapellido = papellido;
            ddireccion = pdireccion;
            dtelefono = ptelefono;
            dmovil = pmovil;
            dsexo = psexo;
            destado = pestado;
            dtipo_de_documento = ptipo_de_documento;
            ddocumento_de_identidad = pdocumento_de_identidad;
        }
        #region metodos get y set
        public int Idcarnet_policial
        {
            get { return dIdcarnet_policial; }
            set { dIdcarnet_policial = value; }
        }
        public string numero_de_carnet
        {
            get { return dnumero_de_carnet; }
            set { dnumero_de_carnet = value; }
        }
        public string nombre
        {
            get { return dnombre; }
            set { dnombre = value; }
        }
        public string apellido
        {
            get { return dapellido; }
            set { dapellido = value; }
        }
        public string direccion
        {
            get { return ddireccion; }
            set { ddireccion = value; }
        }
        public string telefono
        {
            get { return dtelefono; }
            set { dtelefono = value; }
        }
        public string movil
        {
            get { return dmovil; }
            set { dmovil = value; }
        }
        public string sexo
        {
            get { return dsexo; }
            set { dsexo = value; }
        }
        public string estado
        {
            get { return destado; }
            set { destado = value; }
        }
        public string tipo_de_documento
        {
            get { return dtipo_de_documento; }
            set { dtipo_de_documento = value; }
        }
        public string documento_de_identidad
        {
            get { return ddocumento_de_identidad; }
            set { ddocumento_de_identidad = value; }
        }
        #endregion

        //método para insertar un nuevo Suplidor. Recibirá el objeto objSuplidor como parámetro
        public string Insertar(CDEntidadPersonal objCDEntidadPersonal)
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
                SqlCommand micomando = new SqlCommand("PersonalInsertar", sqlCon);
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
                micomando.Parameters.AddWithValue("@pnumero_de_carnet", objCDEntidadPersonal.numero_de_carnet);
                micomando.Parameters.AddWithValue("@pnombre", objCDEntidadPersonal.nombre);
                micomando.Parameters.AddWithValue("@papellido", objCDEntidadPersonal.apellido);
                micomando.Parameters.AddWithValue("@pdireccion", objCDEntidadPersonal.direccion);
                micomando.Parameters.AddWithValue("@ptelefono", objCDEntidadPersonal.telefono);
                micomando.Parameters.AddWithValue("@pmovil", objCDEntidadPersonal.movil);
                micomando.Parameters.AddWithValue("@psexo", objCDEntidadPersonal.sexo);
                micomando.Parameters.AddWithValue("@pestado", objCDEntidadPersonal.estado);
                micomando.Parameters.AddWithValue("@ptipo_de_documento", objCDEntidadPersonal.tipo_de_documento);
                micomando.Parameters.AddWithValue("@pdocumento_de_identidad", objCDEntidadPersonal.documento_de_identidad);
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
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }
        public string Actualizar(CDEntidadPersonal objCDEntidadPersonal)
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
                SqlCommand micomando = new SqlCommand("PersonalActualizar", sqlCon);
                sqlCon.Open(); //Abro la conexión
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdcarnet_policial", objCDEntidadPersonal.Idcarnet_policial);
                micomando.Parameters.AddWithValue("@pnumero_de_carnet", objCDEntidadPersonal.numero_de_carnet);
                micomando.Parameters.AddWithValue("@pnombre", objCDEntidadPersonal.nombre);
                micomando.Parameters.AddWithValue("@papellido", objCDEntidadPersonal.apellido);
                micomando.Parameters.AddWithValue("@ptelefono", objCDEntidadPersonal.telefono);
                micomando.Parameters.AddWithValue("@pmovil", objCDEntidadPersonal.movil);
                micomando.Parameters.AddWithValue("@psexo", objCDEntidadPersonal.sexo);
                micomando.Parameters.AddWithValue("@pestado", objCDEntidadPersonal.estado);
                micomando.Parameters.AddWithValue("@ptipo_de_documento", objCDEntidadPersonal.tipo_de_documento);
                micomando.Parameters.AddWithValue("@pdocumento_de_identidad", objCDEntidadPersonal.documento_de_identidad);
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
        public DataTable Consultar(String objCDEntidadPersonal)
        {
            DataTable dt = new DataTable(); //Se Crea DataTable que tomará los datos de los Suplidores
            SqlDataReader leerDatos; //Creamos el DataReader
            string mensaje = "";
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); //Establecer el comando
                sqlCmd.Connection = new SIGEMPConexion().dbconexion; //Conexión que va a usar el comando
                sqlCmd.Connection.Open(); //Se abre la conexión
                sqlCmd.CommandText = "PersonalConsultar"; //Nombre del Proc. Almacenado a usar
                sqlCmd.CommandType = CommandType.StoredProcedure; //Se trata de un proc. almacenado
                sqlCmd.Parameters.AddWithValue("@pvalor", objCDEntidadPersonal); //Se pasa el valor a buscar
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
