using System;

namespace Arkanoid.Controlador
{
    public class GameOverException : Exception
    { 
        public GameOverException(string Message) : base(Message) {}
    }
}