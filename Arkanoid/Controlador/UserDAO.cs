using System;
using System.Collections.Generic;
using System.Data;

namespace Arkanoid.Modelo
{
    public class UserDAO
    {

        public static bool ExistPlayer(User user)
        {
            string sql = String.Format("select * from usuario where nombre = '{0}';", user.Name);
            
            DataTable dt = ConnectionBDD.ExecuteQuery(sql);

            if (dt.Rows.Count > 0)
                return true;
            
            return false;
        }
        public static User GetPlayer(User usu)
        {
            string sql = String.Format("select * from usuario where nombre = '{0}';", usu.Name);
        
            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
                    
            User user_ = new User();
            foreach (DataRow fila in dt.Rows)
            {
                user_.Id_u = Convert.ToInt32(fila[0].ToString());
                user_.Name = fila[1].ToString();
            }
        
            return user_;
        }

        public static void AddPlayer(User u)
        {
            string sql = String.Format("insert into usuario(nombre) values('{0}');",
                u.Name);
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
    }
}