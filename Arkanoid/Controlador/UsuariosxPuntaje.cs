namespace Arkanoid.Controlador
{
    public class UsuariosxPuntaje
    {
        public string Nombre { get; set; }
        public int Puntaje { get; set; }
        
        public UsuariosxPuntaje() { }

        public UsuariosxPuntaje(string pNombre, int pPuntaje)
        {
            Nombre = pNombre;
            Puntaje = pPuntaje;
        }
    }
}