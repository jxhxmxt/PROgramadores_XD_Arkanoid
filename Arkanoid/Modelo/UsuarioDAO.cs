using System;
using System.Collections.Generic;
using System.Data;

namespace Arkanoid.Modelo
{
    public class UsuarioDAO
    {
        public static List<Usuario> getLista()
        {
            string sql = "select * from usuario";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();
                u.Id_u = Convert.ToInt32(fila[0].ToString());
                u.Nombre = fila[1].ToString();
                
                lista.Add(u);
            }

            return lista;
        }
        
        public static Usuario getUsuario(int id)
        {
            string sql = String.Format("select * from usuario where id_u = {0};", id);

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            Usuario usuario = new Usuario();
            foreach (DataRow fila in dt.Rows)
            {
                usuario.Id_u = Convert.ToInt32(fila[0].ToString());
                usuario.Nombre = fila[1].ToString();
            }

            return usuario;
        }
        
        public static Usuario getUsuario(Usuario usu)
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

        public static void addUsuario(Usuario u)
        {
            string sql = String.Format("insert into usuario(nombre) values('{0}');",
                u.Nombre);
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
    }
}