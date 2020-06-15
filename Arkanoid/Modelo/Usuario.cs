namespace Arkanoid.Modelo
{
    public class Usuario
    {
        public int Id_u { get; set; }
        public string Nombre { get; set; }
        
        public Usuario() { }

        public Usuario(int pId_u, string pNombre)
        {
            Id_u = pId_u;
            Nombre = pNombre;
        }
    }
}