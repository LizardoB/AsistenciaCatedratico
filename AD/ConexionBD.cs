using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    public class ConexionBD
    {

        private String contenido = "server=ingsoftware1290.database.windows.net; database =ingSoftware;user=joalsam; password =ingSoftware1290";
        public SqlConnection conectar = new SqlConnection();
        public SqlDataAdapter adaptador = new SqlDataAdapter();


        public void AbrirConexion()
        {
            string sConn;
            sConn = contenido;
            conectar = new SqlConnection();
            conectar.ConnectionString = sConn;

            try
            {
                conectar.Open();
                Console.WriteLine("Conexión Exitosa");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex + "Fallo en la Conexión");
                throw;
            }
        }

        public void CerrarConexion()
        {
            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
