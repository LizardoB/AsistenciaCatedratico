using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER_ID"] != null)
            {
                if (Session["ID_ASG"] != null)
                {
                    if (Session["ID_EVENTO"] != null)
                    {
                        if (Session["NOMBRE_CURSO"] != null)
                        {
                            if (Session["NOMBRE_EVENTO"] != null)
                            {

                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            ReporteAsistencia cryRpt = new ReporteAsistencia();
            cryRpt.Load(Server.MapPath("ReporteAsistencia.rpt"));
            cryRpt.SetParameterValue("@idAsignacionCatedratico", Convert.ToInt32(Session["ID_ASG"].ToString()));
            cryRpt.SetParameterValue("@idAsignacionEvento", Convert.ToInt32(Session["ID_EVENTO"].ToString()));
            cryRpt.SetParameterValue("@Facultad", "Facultad: Ingeniería en Sistemas, La Antigua Guatemala");
            cryRpt.SetParameterValue("@Catedratico", "Catedrático: "+ Session["NOMBRE_CATEDRATICO"].ToString());
            cryRpt.SetParameterValue("@Curso", "Curso: " + Session["NOMBRE_CURSO"].ToString());
            cryRpt.SetParameterValue("@Evento", Session["NOMBRE_EVENTO"].ToString());

            cryRpt.SetDatabaseLogon("joalsam", "ingSoftware1290");
            CrystalReportViewer1.ReportSource = cryRpt;
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session["USER_ID"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}