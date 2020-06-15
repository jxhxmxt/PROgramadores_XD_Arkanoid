namespace Arkanoid.Modelo
{
    public class Puntuacion
    {
        public int Id_p { get; set; }
        public int Id_u { get; set; }
        public int Puntaje { get; set; }
        
        public Puntuacion() { }

        public Puntuacion(int pId_p, int pId_u, int pPuntaje)
        {
            Id_p = pId_p;
            Id_u = pId_u;
            Puntaje = pPuntaje;
        }
    }
}