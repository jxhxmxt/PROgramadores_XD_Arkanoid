namespace Arkanoid
{
    public static class DataGame
    {
        public static bool startGame = false;
        public static int dirX = 50, dirY = -dirX, score = 0, lives = 3;
        
        public static void RestartGame()
        {
            startGame = false;
            lives = 3;
            score = 0;
        }
    }
}