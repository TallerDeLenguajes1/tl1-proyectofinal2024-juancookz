﻿using System;
using System.Text.Json;
using System.Collections.Generic;

﻿FabricaDePersonajes fabrica = new FabricaDePersonajes();
PersonajesJson personajesJson = new PersonajesJson();
List<Personaje> listaPersonajes = new List<Personaje>();
for (int i = 0; i < 10; i++)
{
    Personaje personaje = fabrica.CrearPersonaje();
    listaPersonajes.Add(personaje);
}
personajesJson.GuardarPersonajes(listaPersonajes, "players_list");

/*
HttpClient client = new HttpClient();
string apiUrl = "https://api.breakingbadquotes.xyz/v1/quotes/2";

try
{
    HttpResponseMessage response = await client.GetAsync(apiUrl);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    List<claseFrase> listaFrases = JsonSerializer.Deserialize<List<claseFrase>>(responseBody);
    foreach (var frase in listaFrases)
    {
        //if (frase.author == "Saul Goodman")
        {
            Console.WriteLine($"Frase: {frase.quote}");
            Console.WriteLine($"Author: {frase.author}");
            Console.WriteLine();
        }
    }
}
catch (HttpRequestException)
{
    System.Console.WriteLine("hubo un error con la API");
    throw;
}*/