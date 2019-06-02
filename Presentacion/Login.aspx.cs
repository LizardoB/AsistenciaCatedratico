using EN;
using LN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {

        CatedraticoEN catedraticoEN;
        CatedraticoLN catedraticoLN;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            catedraticoEN = new CatedraticoEN();
            catedraticoLN = new CatedraticoLN();
            catedraticoEN.Usuario = txtUsuario.Text;
            catedraticoEN.Password = txtPassword.Text;


             if (catedraticoLN.Verificar_Catedratico(catedraticoEN) != 0)
             {
                catedraticoEN.IdCatedratico = catedraticoLN.Verificar_Catedratico(catedraticoEN);
                int id = catedraticoEN.IdCatedratico;
                Session["USER_ID"] = id;
                Session["USER_NAME"] = txtUsuario.Text;
                Session["USER_PASS"] = txtPassword.Text;
                string mensaje = "Ingreso Exitoso";
                 ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                 Response.Redirect("AsignacionesCatedratico.aspx");
             }
             else
             {
                Mensaje.Text = "Usuario o password Incorrecta";
                txtPassword.Text = String.Empty;
                txtUsuario.Text = String.Empty;
                
            }

        }
    }
}