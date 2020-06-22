using System;


namespace Arkanoid.Controlador
{
    public class NicknameLongException : Exception
    {
        public NicknameLongException(string Message) : base(Message){ }
    }
}