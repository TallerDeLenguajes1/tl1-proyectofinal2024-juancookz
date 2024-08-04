public class FabricaDePersonajes
{
    private static readonly Random random = new Random();
    public Personaje CrearPersonaje()
    {
        Personaje personaje = new Personaje
        {
            // Datos
            tipo = GenerarTipoAleatorio(),
            Nombre = GenerarNombreAleatorio(),
            Apodo = GenerarApodoAleatorio(),
            FechaDeNacimiento = GenerarFechaAleatoria(),
            // Características
            Nivel = random.Next(1, 10),
            Salud = 100
        };
        AsignarCaracteristicas(personaje);
        return personaje;
    }
    private void AsignarCaracteristicas(Personaje personaje)
    {
        switch (personaje.tipo)
        {
            case Personaje.Tipo.Defensa:
                personaje.Velocidad = random.Next(1, 5);
                personaje.Destreza = random.Next(1, 5);
                personaje.Fuerza = random.Next(5, 10);
                personaje.Armadura = random.Next(5, 10);
                break;
            case Personaje.Tipo.Soldado:
                personaje.Velocidad = random.Next(5, 10);
                personaje.Destreza = random.Next(1, 5);
                personaje.Fuerza = random.Next(5, 10);
                personaje.Armadura = random.Next(1, 5);
                break;
            case Personaje.Tipo.Medico:
                personaje.Velocidad = random.Next(1, 5);
                personaje.Destreza = random.Next(5, 10);
                personaje.Fuerza = random.Next(1, 5);
                personaje.Armadura = random.Next(5, 10);
                break;
            case Personaje.Tipo.Espia:
                personaje.Velocidad = random.Next(5, 10);
                personaje.Destreza = random.Next(5, 10);
                personaje.Fuerza = random.Next(1, 5);
                personaje.Armadura = random.Next(1, 5);
                break;
        }
        
    }
    private Personaje.Tipo GenerarTipoAleatorio()
    {
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
    private string GenerarNombreAleatorio()
    {
        return "Natalia";
    }

    private string GenerarApodoAleatorio()
    {
        return "Natalia";
    }
    private DateTime GenerarFechaAleatoria()
    {
        Random random = new Random();
        DateTime fecNac = new DateTime(2000, 1, 1);
        fecNac = fecNac.AddDays(random.Next(-(365 * 30), 365));
        return fecNac;
    }
}