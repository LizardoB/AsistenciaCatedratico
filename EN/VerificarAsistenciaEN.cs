using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class VerificarAsistenciaEN
    {


        public int IdCurso;
        public int IdAsignacionCat;
        public int IdCatedratico;
        public string Nombre;

        public VerificarAsistenciaEN()
        {

        }

        public VerificarAsistenciaEN(int idCurso, int idAsignacionCat,int idCatedratico, string nombre)
        {
            IdCurso = idCurso;
            IdAsignacionCat = idAsignacionCat;
            IdCatedratico = idCatedratico;
            Nombre = nombre;

        }

        public int idCurso { get { return IdCurso; } set { IdCurso = value; } }
        public int idAsignacionCat { get { return IdAsignacionCat; } set { IdAsignacionCat = value; } }
        public int idCatedratico { get { return IdCatedratico; } set { IdCatedratico = value; } }
        public String nombre { get { return Nombre; } set { Nombre = value; } }

    }
}
