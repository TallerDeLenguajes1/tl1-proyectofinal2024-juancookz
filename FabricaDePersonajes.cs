using System;
using System.Net.Http;
using System.Threading.Tasks;
public class FabricaDePersonajes
{
    private static readonly Random random = new Random();
    private async Task<Personaje> CrearPersonaje()
    {
        CuerpoDeRespuestaApi respuestaApi = await ApiHelper.ObtenerDatosApi();
        Personaje personaje = new Personaje
        {
            // Datos
            tipo = GenerarTipoAleatorio(),
            Nombre = respuestaApi.Personaje.Nombre,
            Frase = respuestaApi.Frase,
            id = Guid.NewGuid().ToString(),
            FechaDeNacimiento = GenerarFechaAleatoria(),
            // Características
            Nivel = random.Next(1, 10),
            Salud = 100
        };
        AsignarCaracteristicas(personaje);
        return personaje;
    }
    public async Task<List<Personaje>> CrearListaPersonajes()
    {
        List<Personaje> listaPersonajes = new List<Personaje>();
        for (int i = 0; i < 10; i++)
        {
            Personaje personaje = await CrearPersonaje();
            //Metodo Exists, p (cada pj de la lista) entonces p.nombre ¿es igual al nombre del personaje generado?
            if (!listaPersonajes.Exists(p => p.Nombre == personaje.Nombre))
            {
                listaPersonajes.Add(personaje);
            }
            else
            {
                i--;
            }
        }
        return listaPersonajes;
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
    private DateTime GenerarFechaAleatoria()
    {
        Random random = new Random();
        DateTime fecNac = new DateTime(2000, 1, 1);
        fecNac = fecNac.AddDays(random.Next(-(365 * 30), 365));
        return fecNac;
    }
}