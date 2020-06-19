using System;

namespace Arkanoid.Controlador
{
    public class NicknameEmptyException : Exception
    {
        public NicknameEmptyException(string Message) :base(Message){}
    }
}