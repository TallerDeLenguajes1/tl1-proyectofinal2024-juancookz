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

    public Personaje Crear()
    {
        Random random = new Random();
        Personaje personaje = new Personaje();
        //CARACTERISTICAS
        personaje.Velocidad = random.Next(1, 10);
        personaje.Destreza = random.Next(1, 5);
        personaje.Fuerza = random.Next(1, 10);
        personaje.Nivel = random.Next(1, 10);
        personaje.Armadura = random.Next(1, 10);
        personaje.Salud = 100;
        //DATOS
        personaje.tipo = generarTipoAleatorio();
        personaje.FechaDeNacimiento = generarFechaAleatoria();
        return personaje;
    }
    private Personaje.Tipo generarTipoAleatorio()
    {
        Random random = new Random();
        Personaje.Tipo type = new Personaje.Tipo();
        switch (random.Next(0, 3))
        {
            case 0:
                type = Personaje.Tipo.Defensa;
                break;
            case 1:
                type = Personaje.Tipo.Soldado;
                break;
            case 2:
                type = Personaje.Tipo.Medico;
                break;
            case 3:
                type = Personaje.Tipo.Espia;
                break;
            default:
                break;
        }
        return type;
    }
    public DateTime generarFechaAleatoria()
    {
        Random random = new Random();
        DateTime fecNac = new DateTime(2000, 1, 1);
        fecNac = fecNac.AddDays(random.Next(-(365 * 30),365));
        return fecNac;
    }

    public void Mostrar()
    {
        System.Console.WriteLine("PERSONAJE:");
        System.Console.WriteLine("--- DATOS ---");
        System.Console.WriteLine("Nombre: " + Nombre);
        System.Console.WriteLine("Apodo: " + Apodo);
        //System.Console.WriteLine("Tipo: " + Tipo);
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
