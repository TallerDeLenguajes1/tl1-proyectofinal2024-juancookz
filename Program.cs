using System;
using System.Collections.Generic;
using System.Threading.Tasks;

FabricaDePersonajes fabrica = new FabricaDePersonajes();
PersonajesJson personajesJson = new PersonajesJson();
List<Personaje> listaPersonajes = new List<Personaje>();

listaPersonajes = await fabrica.CrearListaPersonajes();

personajesJson.GuardarPersonajes(listaPersonajes, "players_list");

List<Personaje> listaPjsJson = personajesJson.LeerPersonajes("players_list");

foreach (var personaje in listaPjsJson)
{
    personaje.Mostrar();
}