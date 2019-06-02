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
    public class VerificarAsistenciaAD
    {
        ConexionBD conectar;

        public int Verificar_Asistencia(VerificarAsistenciaEN verificarAsistenciaEN)
        {
            int NoIngreso = 0;
            conectar = new ConexionBD();
            SqlCommand cmd = new SqlCommand("VerificarAsistenciaEstudiante");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCurso", verificarAsistenciaEN.IdCurso);
            cmd.Parameters.AddWithValue("@idAsignacionCat", verificarAsistenciaEN.IdAsignacionCat);
            cmd.Parameters.AddWithValue("@nombre", verificarAsistenciaEN.Nombre);

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


        public int GetIdAsistencia(int idAsignacionEvento)
        {
            int NoIngreso = 0;
            conectar = new ConexionBD();
            SqlCommand cmd = new SqlCommand("GetIdAsistencia");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idAsignacionEvento", idAsignacionEvento);

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



        public int Actualizar_Asistencia(int idAsistencia,int idEstudiante)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            SqlCommand procedimiento = new SqlCommand("ActualizarAsistencia");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("@idAsistencia", idAsistencia);
            procedimiento.Parameters.AddWithValue("@idEstudiante", idEstudiante);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;

        }


    }
}
