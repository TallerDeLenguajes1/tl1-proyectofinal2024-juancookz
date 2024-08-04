public class Personaje
{
    // Datos del personaje
    public enum Tipo
    {
        Defensa,
        Soldado,
        Medico,
        Espia,
    }
    public Tipo tipo { get; set; }
    public string Nombre { get; set; }
    public string Apodo { get; set; }
    public DateTime FechaDeNacimiento { get; set; }
    public int Edad(DateTime FecNac)
    {
        int edad = 0;
        DateTime FecHoy = DateTime.Now;
        edad = FecHoy.Year - FecNac.Year;
        if (FecHoy.DayOfYear < FecNac.DayOfYear)
        {
            edad = edad - 1;
        }
        return edad;
    }

    // Características del personaje
    public int Velocidad { get; set; }
    public int Destreza { get; set; }
    public int Fuerza { get; set; }
    public int Nivel { get; set; }
    public int Armadura { get; set; }
    public int Salud { get; set; }

    public void Mostrar()
    {
        System.Console.WriteLine("PERSONAJE:");
        System.Console.WriteLine("--- DATOS ---");
        System.Console.WriteLine("Tipo: " + tipo);
        System.Console.WriteLine("Nombre: " + Nombre);
        System.Console.WriteLine("Apodo: " + Apodo);
        System.Console.WriteLine("FecNac: " + FechaDeNacimiento.Day + "/" + FechaDeNacimiento.Month + "/" + FechaDeNacimiento.Year);
        System.Console.WriteLine("Edad: " + Edad(FechaDeNacimiento));
        System.Console.WriteLine("--- CARACTERISTICAS ---");
        System.Console.WriteLine("Velocidad: " + Velocidad);
        System.Console.WriteLine("Destreza: " + Destreza);
        System.Console.WriteLine("Fuerza: " + Fuerza);
        System.Console.WriteLine("Nivel: " + Nivel);
        System.Console.WriteLine("Armadura: " + Armadura);
        System.Console.WriteLine("Salud: " + Salud);
    }
}