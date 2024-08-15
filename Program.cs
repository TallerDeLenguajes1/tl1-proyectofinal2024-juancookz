using System;
using System.Collections.Generic;
using System.Threading.Tasks;

PersonajesJson personajesJson = new PersonajesJson();
HistorialJson historialJson = new HistorialJson();
List<Personaje> listaPersonajes = new List<Personaje>();
Random random = new Random();
int vidas = 3;

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

int jugadorUsuario = ElegirPersonaje(listaPersonajes);

Personaje personajeUsuario = listaPersonajes[jugadorUsuario];
Console.Clear();
System.Console.WriteLine("has seleccionado a:");
personajeUsuario.Mostrar();
Thread.Sleep(4000);
int jugadorComputadora = -1;
Personaje personajeComputadora = listaPersonajes[jugadorUsuario];
while (listaPersonajes.Count > 1 && vidas > 0)
{
    Console.Clear();
    // esto sucede en el caso que el juego este iniciando y la computadora no tenga personaje asignado o que haya perdido y vaya a asignarsele un nuevo personaje
    if (jugadorComputadora == -1)
    {
        do
        {
            jugadorComputadora = random.Next(0, listaPersonajes.Count);
        } while (jugadorComputadora == jugadorUsuario);
        personajeComputadora = listaPersonajes[jugadorComputadora];
    }
    Console.WriteLine("Pelearás contra el siguiente personaje...");
    personajeComputadora.Mostrar();
    Thread.Sleep(3000);

    bool usuarioGano = Batalla(personajeUsuario, personajeComputadora);

    if (usuarioGano)
    {
        personajeUsuario.Nivel += 1;
        personajeUsuario.Salud = 100;
        System.Console.WriteLine("GANASTE!");
        System.Console.WriteLine("te quedan " + vidas + " vidas.");
        System.Console.Write(personajeUsuario.Nombre + " dice: ");
        EscribirFrase(personajeUsuario.Frase);
        System.Console.WriteLine("Has subido a nivel " + personajeUsuario.Nivel);
        System.Console.WriteLine(personajeComputadora.Nombre + " HA SIDO ELIMINADO!");
        listaPersonajes.RemoveAt(jugadorComputadora);
        jugadorComputadora = -1;
    }
    else
    {
        personajeComputadora.Salud = 100;
        vidas--;
        System.Console.WriteLine("PERDISTE!");
        System.Console.WriteLine("te quedan " + vidas + " vidas.");

        System.Console.Write(personajeComputadora.Nombre + " dice: ");
        EscribirFrase(personajeComputadora.Frase);
        System.Console.WriteLine(personajeUsuario.Nombre + " HA SIDO ELIMINADO!");
        System.Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
        Console.ReadKey();
        if (listaPersonajes.Count > 1 && vidas > 0)
        {
            do
            {
                listaPersonajes.RemoveAt(jugadorUsuario);
                jugadorUsuario = ElegirPersonaje(listaPersonajes);
                personajeUsuario = listaPersonajes[jugadorUsuario];
                if (personajeUsuario == personajeComputadora)
                {
                    System.Console.WriteLine("Por favor, elige otro personaje ya que este pertenece a la computadora");
                }
            } while (personajeUsuario == personajeComputadora);
        }
    }
    System.Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
    Console.ReadKey();
}
Console.Clear();
if (vidas == 0)
{
    EscribirFrase("PERDISTE EL TORNEO, GRACIAS POR PARTICIPAR");
    System.Console.WriteLine("");
    System.Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CONTINUAR");
    Console.ReadKey();
}
else
{
    System.Console.WriteLine("FELICIDADES, HAS GANADO EL TORNEO!");
    Console.WriteLine("Tu personaje ganador es:");
    listaPersonajes[0].Mostrar();
    historialJson.GuardarGanador(listaPersonajes[0], "winners_list");
}
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

bool Batalla(Personaje atacante, Personaje defensor)
{
    int danio = 0;
    while (defensor.Salud > 0 && atacante.Salud > 0)
    {
        // ATACA USUARIO
        danio = Combate(atacante, defensor);
        defensor.Salud -= danio;

        if (defensor.Salud <= 0)
        {
            defensor.Salud = 0;
            return true; // Usuario ganó
        }

        StatsAtaque(atacante, danio);
        Thread.Sleep(750);

        // ATACA COMPUTADORA
        danio = Combate(defensor, atacante);
        atacante.Salud -= danio;

        if (atacante.Salud <= 0)
        {
            atacante.Salud = 0;
            return false; // Computadora ganó
        }

        StatsAtaque(defensor, danio);
        Thread.Sleep(750);
    }
    return false;
}

static void StatsAtaque(Personaje atacante, int danio)
{
    System.Console.WriteLine("------------------");
    System.Console.WriteLine("ATACA");
    System.Console.WriteLine(atacante.Nombre);
    System.Console.WriteLine("Daño provocado: " + danio);
    System.Console.WriteLine("Salud: " + atacante.Salud);
    System.Console.WriteLine("------------------");
}

int ElegirPersonaje(List<Personaje> listaPersonajes)
{
    EscribirFrase("Por favor, elige tu personaje");
    Thread.Sleep(1000);
    MostrarListaPersonajes(listaPersonajes);

    string opcion = "";
    int jugadorUsuario = -1;
    while (!Int32.TryParse(opcion, out jugadorUsuario) || jugadorUsuario < 0 || jugadorUsuario >= listaPersonajes.Count)
    {
        System.Console.WriteLine("Ingresa el Nº de tu personaje");
        opcion = Console.ReadLine();
    }

    return jugadorUsuario;
}