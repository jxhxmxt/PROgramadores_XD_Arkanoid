namespace Arkanoid.Modelo
{
    public class User
    {
        public int Id_u { get; set; }
        public string Name { get; set; }
        
        public User() { }

        public User(int pId_u, string pName)
        {
            Id_u = pId_u;
            Name = pName;
        }
    }
}