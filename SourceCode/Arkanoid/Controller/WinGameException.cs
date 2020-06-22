using System;

namespace Arkanoid.Controlador
{
    public class WinGameException : Exception
    {
        public WinGameException(string Message) : base(Message) {}
    }
}