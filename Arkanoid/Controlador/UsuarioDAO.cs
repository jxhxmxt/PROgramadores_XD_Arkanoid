using System;
using System.Collections.Generic;
using System.Data;

namespace Arkanoid.Modelo
{
    public class UsuarioDAO
    {

        public static bool ExistPlayer(Usuario user)
        {
            string sql = String.Format("select * from usuario where nombre = '{0}';", user.Nombre);
            
            DataTable dt = ConnectionBDD.ExecuteQuery(sql);

            if (dt.Rows.Count > 0)
                return true;
            
            return false;
        }
        public static Usuario GetPlayer(Usuario usu)
        {
            string sql = String.Format("select * from usuario where nombre = '{0}';", usu.Nombre);
        
            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
                    
            Usuario usuario = new Usuario();
            foreach (DataRow fila in dt.Rows)
            {
                usuario.Id_u = Convert.ToInt32(fila[0].ToString());
                usuario.Nombre = fila[1].ToString();
            }
        
            return usuario;
        }

        public static void AddPlayer(Usuario u)
        {
            string sql = String.Format("insert into usuario(nombre) values('{0}');",
                u.Nombre);
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
    }
}