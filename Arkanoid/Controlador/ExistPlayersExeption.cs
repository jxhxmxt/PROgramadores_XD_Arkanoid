using System;

namespace Arkanoid.Controlador
{
    public class ExistPlayersExeption : Exception
    {
        public ExistPlayersExeption(string Message) : base(Message){}
    }
}