namespace Arkanoid.Modelo
{
    public class Score
    {
        public int Id_p { get; set; }
        public int Id_u { get; set; }
        public int Score_ { get; set; }
        
        public Score() { }

        public Score(int pId_p, int pId_u, int pScore)
        {
            Id_p = pId_p;
            Id_u = pId_u;
            Score_ = pScore;
        }
    }
}