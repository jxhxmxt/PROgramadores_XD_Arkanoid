using System;
using System.Collections.Generic;
using System.Data;
using Arkanoid.Controlador;

namespace Arkanoid.Modelo
{
    public class ScoreDAO
    {
        public static List<Score> getLista()
        {
            string sql = "select * from puntuacion order by puntaje desc limit 10";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);

            List<Score> list = new List<Score>();
            foreach (DataRow row in dt.Rows)
            {
                Score p = new Score();
                p.Id_p = Convert.ToInt32(row[0].ToString());
                p.Id_u = Convert.ToInt32(row[1].ToString());
                p.Score_ = Convert.ToInt32(row[2].ToString());

                list.Add(p);
            }

            return list;
        }

        public static List<UsserxScore> getTop(List<Score> p)
        {
            List<UsserxScore> list = new List<UsserxScore>();

            foreach (Score score in p)
            {
                string sql = String.Format("select * from usuario where id_u = {0};", score.Id_u);

                DataTable dt = ConnectionBDD.ExecuteQuery(sql);
                
                UsserxScore uxp = new UsserxScore();
                foreach (DataRow row in dt.Rows)
                {
                    uxp.Name = row[1].ToString();
                }
                uxp.Score = score.Score_;
                
                list.Add(uxp);
            }

            return list;
        }
        
        public static void AddScore(int id, int puntaje)
                {
                    string sql = String.Format("insert into puntuacion(id_u, puntaje) values({0}, {1});", id, puntaje);
        
                    ConnectionBDD.ExecuteNonQuery(sql);
                }
    }
}