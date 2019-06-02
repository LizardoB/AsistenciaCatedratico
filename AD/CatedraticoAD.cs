using EN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    public class CatedraticoAD
    {
        ConexionBD conectar;

        public int Verificar_Usuario(CatedraticoEN catedraticoEN)
        {
            int NoIngreso = 0;

            conectar = new ConexionBD();
            SqlCommand cmd = new SqlCommand("Verificar_usuario");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", catedraticoEN.Usuario);
            cmd.Parameters.AddWithValue("@pass", catedraticoEN.Password);

            conectar.AbrirConexion();
            cmd.Connection = conectar.conectar;

            try
            {
                NoIngreso = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                NoIngreso = 0;

            }

            conectar.CerrarConexion();
            return NoIngreso;
        }

        public string Nombre_Catedratico(string user, string pass)
        {
            string nombre = "";

            conectar = new ConexionBD();
            SqlCommand cmd = new SqlCommand("Nombre_Catedratico");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            conectar.AbrirConexion();
            cmd.Connection = conectar.conectar;

            try
            {
                nombre = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                nombre = "Error";

            }

            conectar.CerrarConexion();
            return nombre;
        }

        public DataTable clsAsignaiconCatedratico(int idCatedratico)
        {
            try
            {
                conectar = new ConexionBD();
                DataTable tabla = new DataTable();
                conectar.AbrirConexion();
                string strConsulta = string.Format("exec clsAsignacionCat '" + idCatedratico + "';");
                SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public DataTable clsEventoCatedratico(int idAsgCat)
        {
            try
            {
                conectar = new ConexionBD();
                DataTable tabla = new DataTable();
                conectar.AbrirConexion();
                string strConsulta = string.Format("exec clsAsignacionEvento '" + idAsgCat + "';");
                SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            catch (Exception e)
            {

                throw e;
            }

        }


    }
}
