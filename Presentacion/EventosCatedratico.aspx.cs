using LN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class EventosCatedratico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatedraticoLN catedraticoLN = new CatedraticoLN();

            if (Session["USER_ID"] != null)
            {
                if (Session["ID_ASG"] != null)
                {
                    if (Session["ID_CURSO"] != null)
                    {
                        if (Session["NOMBRE_CURSO"] != null)
                        {
                            if (Session["ID_GROUP"] != null)
                            {
                                int id = Convert.ToInt32(Session["ID_ASG"].ToString());
                                catedraticoLN.gridEventoCatedratico(GridEventos, id);
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }


        protected void GridCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Asistencia")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridEventos.Rows[index];
                TableCell idAsignacionEvento = selectedRow.Cells[2];
                TableCell nombreEvento = selectedRow.Cells[4];
                string id = idAsignacionEvento.Text;
                string NombreEvento = nombreEvento.Text;

                Session["ID_EVENTO"] = id;
                Session["NOMBRE_EVENTO"] = NombreEvento;
                Response.Redirect("TomaAsistencia.aspx");
            }
            else if (e.CommandName == "VerAsistencia")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridEventos.Rows[index];
                TableCell idAsignacionEvento = selectedRow.Cells[2];
                TableCell nombreEvento = selectedRow.Cells[4];
                string id = idAsignacionEvento.Text;
                string NombreEvento = nombreEvento.Text;

                Session["ID_EVENTO"] = id;
                Session["NOMBRE_EVENTO"] = NombreEvento;
                Response.Redirect("Reporte.aspx");
            }
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session["USER_ID"] = null;
            Response.Redirect("Login.aspx");
        }
        
    }
}