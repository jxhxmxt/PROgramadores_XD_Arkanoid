namespace Arkanoid.Controlador
{
    public class UsserxScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        
        public UsserxScore() { }

        public UsserxScore(string pName, int pScore)
        {
            Name = pName;
            Score = pScore;
        }
    }
}