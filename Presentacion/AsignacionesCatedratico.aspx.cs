using LN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AsignacionesCatedratico : System.Web.UI.Page
    {
        

            protected void Page_Load(object sender, EventArgs e)
            {
                CatedraticoLN  catedraticoLN = new CatedraticoLN();

                if (Session["USER_ID"] != null)
                {
                    int id = Convert.ToInt32(Session["USER_ID"].ToString());
                    catedraticoLN.gridAsignacionCatedratico(GridCatedratico, id);

                    string nombreCatedratico = catedraticoLN.Nombre_Catedratico(Session["USER_NAME"].ToString(), Session["USER_PASS"].ToString());
                    Session["NOMBRE_CATEDRATICO"] = nombreCatedratico;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }


            }

        protected void GridCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Evento")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridCatedratico.Rows[index];
                TableCell idAsignacion = selectedRow.Cells[1];
                TableCell idCur = selectedRow.Cells[2];
                TableCell nombreCurso = selectedRow.Cells[3];
                TableCell idGrupo = selectedRow.Cells[5];
                string idAsg = idAsignacion.Text;
                string idCurso = idCur.Text;
                string personGroupID = idGrupo.Text;
                string NombreCurso = nombreCurso.Text;

                Session["ID_ASG"] = idAsg;
                Session["ID_CURSO"] = idCurso;
                Session["ID_GROUP"] = personGroupID;
                Session["NOMBRE_CURSO"] = NombreCurso;
                Response.Redirect("EventosCatedratico.aspx");
            }
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session["USER_ID"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}