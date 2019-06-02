using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class CatedraticoEN
    {
        public int IdCatedratico;
        public String Nombres;
        public String Apellidos;
        public String Email;
        public String Usuario;
        public String Password;

        public CatedraticoEN()
        {

        }

        public CatedraticoEN(int idCatedratico, string nombres, string apellidos, string email, string usuario, string password)
        {
            IdCatedratico = idCatedratico;
            Nombres = nombres;
            Apellidos = apellidos;
            Email = email;
            Usuario = usuario;
            Password = password;

        }


        public int idCatedratico { get { return IdCatedratico; } set { IdCatedratico = value; } }
        public String nombres { get { return Nombres; } set { Nombres = value; } }
        public String apellidos { get { return Apellidos; } set { Apellidos = value; } }
        public String email { get { return Email; } set { Email = value; } }
        public String usuario { get { return Usuario; } set { Usuario = value; } }
        public String password { get { return Password; } set { Password = value; } }
    }
}
