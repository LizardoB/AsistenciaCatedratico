using EN;
using LN;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{


    public class Respuesta
    {
        public string personGroupId { get; set; }
        public string[] faceIds { get; set; }
        public int maxNumOfCandidatesReturned { get; set; }
        public float confidenceThreshold { get; set; }

    }


        public class GetPersonResponse
        {
            public string personId { get; set; }
            public string[] persistedFaceIds { get; set; }
            public string name { get; set; }
            public string userData { get; set; }

        }


        public partial class TomaAsistencia : System.Web.UI.Page
    {
        VerificarAsistenciaLN verificarAsistenciaLN;
        VerificarAsistenciaEN verificarAsistenciaEN;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                if (Session["ID_ASG"] != null)
                {
                    if (Session["ID_GROUP"] != null)
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

        }
        public async void Detect()
        {

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            var queryString2 = HttpUtility.ParseQueryString(string.Empty);
            queryString["returnFaceId"] = "true";
            queryString2["recognitionModel"] = "recognition_02";


            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "f79cd591035a4ffcb2a30b96c38a7532");


            var uri = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/detect?" + queryString + "&" + queryString2;

            HttpResponseMessage response;

            string cadena = TextBox1.Text;
            int sitioDeCorte = 22;
            string parte1 = cadena.Substring(0, sitioDeCorte);
            string parte2 = cadena.Substring(sitioDeCorte + 1);

            byte[] bytesData = System.Convert.FromBase64String(parte2);



            using (ByteArrayContent content = new ByteArrayContent(bytesData))
            {

                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                response = await client.PostAsync(uri, content);
                string contentString = await response.Content.ReadAsStringAsync();

                dynamic jsonObj = JsonConvert.DeserializeObject(contentString);
                var numero = jsonObj[0]["faceId"].ToString();
                Identify(numero);

            }


        }



        public async void Identify(string id)
        {

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["PersonGroupId"] = "true";
            queryString["faceIds"] = "true";

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "f79cd591035a4ffcb2a30b96c38a7532");


            var uri = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/identify";

            HttpResponseMessage response;

            Respuesta person = new Respuesta();
            person.personGroupId = Session["ID_GROUP"].ToString();
            String personGroupID = person.personGroupId;
            person.faceIds = new string[] { id };
            person.maxNumOfCandidatesReturned = 1;
            person.confidenceThreshold = 0.5f;



            string json = JsonConvert.SerializeObject(person);


            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            response = await client.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                dynamic jsonObj = JsonConvert.DeserializeObject(content);
                var ID = jsonObj[0]["candidates"].ToString();

                dynamic blogPosts = JArray.Parse(ID);
                try
                {
                    dynamic blogPost = blogPosts[0];
                    string personID = blogPost.personId;
                    Verificar(personGroupID, personID);
                }
                catch (Exception e)
                {
                    string mensaje = "Verificacion Fallida Intente nuevamente";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                }


            }



        }


        public async void Verificar(string personGroupID, string personID)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(personGroupID);
            var queryString2 = HttpUtility.ParseQueryString(personID);

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "f79cd591035a4ffcb2a30b96c38a7532");

            var uri = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/" + queryString + "/persons/" + queryString2 ;
            
            var response = await client.GetAsync(uri);
            int asignacion = Convert.ToInt32(Session["ID_ASG"].ToString());
            int curso = Convert.ToInt32(Session["ID_CURSO"].ToString());
            int evento = Convert.ToInt32(Session["ID_EVENTO"].ToString());
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetPersonResponse>(content);
                var name = result.name;
                string estudiante = name;
                TraerID(estudiante,curso, asignacion,evento);
            }


        }

        public void TraerID(string nombre, int idCurso, int idAsignacion, int evento)
        {
            verificarAsistenciaEN = new VerificarAsistenciaEN();
            verificarAsistenciaLN = new VerificarAsistenciaLN();

            verificarAsistenciaEN.IdAsignacionCat = idAsignacion;
            verificarAsistenciaEN.IdCurso = idCurso;
            verificarAsistenciaEN.Nombre = nombre;
            verificarAsistenciaEN.IdCatedratico = verificarAsistenciaLN.Verificar_Asistencia(verificarAsistenciaEN);
            int Estudiante = verificarAsistenciaEN.IdCatedratico;
            int Asistencia = verificarAsistenciaLN.GetIdAsistencia(evento);


            if (verificarAsistenciaEN.IdCatedratico != 0)
            {

                if (verificarAsistenciaLN.ActualizarAsistencia(Asistencia, Estudiante) == 1)
                {
                    string mensaje = "Ingreso Exitoso ";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                }
            }

        }



        protected void Unnamed_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Detect();
        }

        protected void FinalizarAsistencia(object sender, EventArgs e)
        {
            Response.Redirect("Reporte.aspx");
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session["USER_ID"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}