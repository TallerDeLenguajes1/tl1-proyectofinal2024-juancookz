using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        FabricaDePersonajes fabrica = new FabricaDePersonajes();
        PersonajesJson personajesJson = new PersonajesJson();
        List<Personaje> listaPersonajes = new List<Personaje>();

        for (int i = 0; i < 10; i++)
        {
            Personaje personaje = await fabrica.CrearPersonaje();
            listaPersonajes.Add(personaje);
        }
        personajesJson.GuardarPersonajes(listaPersonajes, "players_list");
        List<Personaje> listaPjsJson = personajesJson.LeerPersonajes("players_list");
        foreach (var personaje in listaPjsJson)
        {
            personaje.Mostrar();
        }
    }
}
