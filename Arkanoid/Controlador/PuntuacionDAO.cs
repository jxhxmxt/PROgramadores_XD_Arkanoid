using System;
using System.Collections.Generic;
using System.Data;
using Arkanoid.Controlador;

namespace Arkanoid.Modelo
{
    public class PuntuacionDAO
    {
        public static List<Puntuacion> getLista()
        {
            string sql = "select * from puntuacion order by puntaje desc limit 10";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);

            List<Puntuacion> lista = new List<Puntuacion>();
            foreach (DataRow fila in dt.Rows)
            {
                Puntuacion p = new Puntuacion();
                p.Id_p = Convert.ToInt32(fila[0].ToString());
                p.Id_u = Convert.ToInt32(fila[1].ToString());
                p.Puntaje = Convert.ToInt32(fila[2].ToString());

                lista.Add(p);
            }

            return lista;
        }

        public static List<UsuariosxPuntaje> getTop(List<Puntuacion> p)
        {
            List<UsuariosxPuntaje> lista = new List<UsuariosxPuntaje>();

            foreach (Puntuacion puntuacion in p)
            {
                string sql = String.Format("select * from usuario where id_u = {0};", puntuacion.Id_u);

                DataTable dt = ConnectionBDD.ExecuteQuery(sql);
                
                UsuariosxPuntaje uxp = new UsuariosxPuntaje();
                foreach (DataRow fila in dt.Rows)
                {
                    uxp.Nombre = fila[1].ToString();
                }
                uxp.Puntaje = puntuacion.Puntaje;
                
                lista.Add(uxp);
            }

            return lista;
        }
        
        public static void addPuntuacion(int id, int puntaje)
                {
                    string sql = String.Format("insert into puntuacion(id_u, puntaje) values({0}, {1});", id, puntaje);
        
                    ConnectionBDD.ExecuteNonQuery(sql);
                }
    }
}