using AD;
using EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN
{
    public class VerificarAsistenciaLN
    {
        VerificarAsistenciaAD verificarAsistenciaAD;

        public int Verificar_Asistencia(VerificarAsistenciaEN verificarAsistenciaEN)//id
        {
            verificarAsistenciaAD = new VerificarAsistenciaAD();
            return verificarAsistenciaAD.Verificar_Asistencia(verificarAsistenciaEN);
        }

        public int GetIdAsistencia(int idAsignacionEvento)//id
        {
            verificarAsistenciaAD = new VerificarAsistenciaAD();
            return verificarAsistenciaAD.GetIdAsistencia(idAsignacionEvento);
        }

        public int ActualizarAsistencia(int idAsistencia,int idEstudiante)
        {
            verificarAsistenciaAD = new VerificarAsistenciaAD();
            return verificarAsistenciaAD.Actualizar_Asistencia(idAsistencia, idEstudiante);
        }




    }
}
