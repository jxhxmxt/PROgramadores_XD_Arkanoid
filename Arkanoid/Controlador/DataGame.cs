using System;

namespace Arkanoid
{
    public static class DataGame
    {
        public static bool startGame = false, bigPlayer = false, smallPlayer = false;
        public static bool normalPlayer = true, timeDurationStart = false;
        public static int dirX = 35, dirY = -dirX, score = 0, lives = 3;
        public static int resizingTimeDuration = 0;

        public static void RestartGame()
        {
            startGame = false;
            lives = 3;
            score = 0;
        }

        public static int RandomScore()
        {
            Random random = new Random();

            return random.Next(4, 9);
        }
    }
}