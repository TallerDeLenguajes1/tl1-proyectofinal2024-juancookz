using System;
using System.Collections.Generic;
using System.Threading.Tasks;

PersonajesJson personajesJson = new PersonajesJson();
HistorialJson historialJson = new HistorialJson();
List<Personaje> listaPersonajes = new List<Personaje>();
Random random = new Random();
// SI NO EXISTE LISTA DE PERSONAJES
if (!personajesJson.ExisteListaPersonajes("players_list"))
{
    FabricaDePersonajes fabrica = new FabricaDePersonajes();
    listaPersonajes = await fabrica.CrearListaPersonajes();
    personajesJson.GuardarPersonajes(listaPersonajes, "players_list");
}
// LEO LA LISTA DE PERSONAJES LOCAL
else
{
    listaPersonajes = personajesJson.LeerPersonajes("players_list");
}
// IMPRIMO POR CONSOLA LA LISTA DE PERSONAJES
Console.Clear();
System.Console.WriteLine("Bienvenid@ a A GAME OF ICE AND FIRE");
Thread.Sleep(750);
EscribirFrase("Por favor, elige tu personaje");
Thread.Sleep(1000);
MostrarListaPersonajes(listaPersonajes);

string opcion = "";
int jugadorUsuario;
int jugadorComputadora = 0;
while (!Int32.TryParse(opcion, out jugadorUsuario) || jugadorUsuario < 0 || jugadorUsuario > listaPersonajes.Count)
{
    System.Console.WriteLine("Ingresa el Nº de tu personaje");
    opcion = Console.ReadLine();
}
Console.Clear();
System.Console.WriteLine("has seleccionado a:");
listaPersonajes[jugadorUsuario].Mostrar();
Thread.Sleep(4000);
Console.Clear();
System.Console.WriteLine("Pelearas contra un personaje aleatorio, este es...");
do
{
    jugadorComputadora = random.Next(0, listaPersonajes.Count);
} while (jugadorComputadora == jugadorUsuario);
listaPersonajes[jugadorComputadora].Mostrar();
Thread.Sleep(3000);
Console.Clear();
int danio = 0;

while (listaPersonajes[jugadorComputadora].Salud > 0 && listaPersonajes[jugadorUsuario].Salud > 0)
{
    // ATACA USUARIO
    danio = Combate(listaPersonajes[jugadorUsuario], listaPersonajes[jugadorComputadora]);
    listaPersonajes[jugadorComputadora].Salud -= danio;

    if (listaPersonajes[jugadorComputadora].Salud <= 0)
    {
        listaPersonajes[jugadorComputadora].Salud = 0;
        break;
    }

    StatsAtaque(listaPersonajes, jugadorUsuario, danio);
    Thread.Sleep(750);

    // ATACA COMPUTADORA
    danio = Combate(listaPersonajes[jugadorComputadora], listaPersonajes[jugadorUsuario]);
    listaPersonajes[jugadorUsuario].Salud -= danio;

    if (listaPersonajes[jugadorUsuario].Salud <= 0)
    {
        listaPersonajes[jugadorUsuario].Salud = 0;
        break;
    }

    StatsAtaque(listaPersonajes, jugadorComputadora, danio);
    Thread.Sleep(750);
}
//SI GANA USUARIO
if (listaPersonajes[jugadorComputadora].Salud <= 0)
{
    listaPersonajes[jugadorUsuario].Nivel += 1;
    listaPersonajes[jugadorUsuario].Salud = 100;
    Thread.Sleep(400);
    System.Console.WriteLine("GANASTE!");
    System.Console.Write(listaPersonajes[jugadorUsuario].Nombre + " dice: ");
    EscribirFrase(listaPersonajes[jugadorUsuario].Frase);
    System.Console.WriteLine("Has subido a nivel " + listaPersonajes[jugadorUsuario].Nivel);
    Thread.Sleep(500);
    System.Console.WriteLine(listaPersonajes[jugadorComputadora].Nombre + " A SIDO ELIMINADO!");
    historialJson.GuardarGanador(listaPersonajes[jugadorUsuario], "winners_list");
    listaPersonajes.RemoveAt(jugadorComputadora);
    System.Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
    Console.ReadKey();
}
//SI GANA COMPUTADORA
if (listaPersonajes[jugadorUsuario].Salud <= 0)
{
    listaPersonajes[jugadorComputadora].Salud = 100;
    System.Console.WriteLine("PERDISTE!");
    System.Console.Write(listaPersonajes[jugadorComputadora].Nombre + " dice: ");
    EscribirFrase(listaPersonajes[jugadorComputadora].Frase);
    Thread.Sleep(100);
    System.Console.WriteLine(listaPersonajes[jugadorUsuario].Nombre + " A SIDO ELIMINADO!");
    historialJson.GuardarGanador(listaPersonajes[jugadorComputadora], "winners_list");
    listaPersonajes.RemoveAt(jugadorUsuario);
    System.Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
    Console.ReadKey();
}

personajesJson.GuardarPersonajes(listaPersonajes, "players_list");

if (historialJson.ExisteListaPersonajes("winners_list"))
{
    Console.Clear();
    System.Console.WriteLine("LISTADO DE GANADORES HISTORICOS");
    MostrarListaPersonajes(historialJson.LeerGanadores("winners_list"));
    System.Console.WriteLine("PRESIONE CUALQUIER TECLA PARA SALIR");
    Console.ReadKey();
}

void EscribirFrase(string mensaje)
{
    foreach (char letra in mensaje)
    {
        Console.Write(letra);
        Thread.Sleep(40);
    }
    Console.WriteLine();
}
void MostrarListaPersonajes(List<Personaje> listaPersonajes)
{
    for (int i = 0; i < listaPersonajes.Count; i++)
    {
        System.Console.WriteLine("PERSONAJE:" + i);
        Personaje personaje = listaPersonajes[i];
        personaje.Mostrar();
    }
}
int Combate(Personaje atacante, Personaje defensor)
{
    int ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
    int efectividad = random.Next(1, 100);
    int defensa = defensor.Armadura * defensor.Velocidad;
    int danio = ((ataque * efectividad) - defensa) / 500;
    return danio;
}
static void StatsAtaque(List<Personaje> listaPersonajes, int jugadorUsuario, int danio)
{
    System.Console.WriteLine("------------------");
    System.Console.WriteLine("ATACA");
    System.Console.WriteLine(listaPersonajes[jugadorUsuario].Nombre);
    System.Console.WriteLine("Daño provocado: " + danio);
    System.Console.WriteLine("Salud: " + listaPersonajes[jugadorUsuario].Salud);
    System.Console.WriteLine("------------------");
}