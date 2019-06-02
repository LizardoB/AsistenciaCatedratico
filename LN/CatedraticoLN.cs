using AD;
using EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LN
{
    public class CatedraticoLN
    {
        CatedraticoAD catedraticoAD;

        public int Verificar_Catedratico(CatedraticoEN catedraticoEN)//id
        {
            catedraticoAD = new CatedraticoAD();
            return catedraticoAD.Verificar_Usuario(catedraticoEN);
        }

        public string Nombre_Catedratico(string user, string pass)
        {
            catedraticoAD = new CatedraticoAD();
            return catedraticoAD.Nombre_Catedratico(user, pass);
        }

        public void gridAsignacionCatedratico(GridView grid, int id)
        {
            catedraticoAD = new CatedraticoAD();
            grid.DataSource = catedraticoAD.clsAsignaiconCatedratico(id);
            grid.DataBind();
        }

        public void gridEventoCatedratico(GridView grid, int id)
        {
            catedraticoAD = new CatedraticoAD();
            grid.DataSource = catedraticoAD.clsEventoCatedratico(id);
            grid.DataBind();
        }


    }
}
