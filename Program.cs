using System;
using System.Text.Json;
using System.Collections.Generic;

HttpClient client = new HttpClient();
string apiUrl = "https://api.breakingbadquotes.xyz/v1/quotes/2";

Console.Clear();

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
}

//Creamos una instancia de producto
Producto papas = new Producto
{
    Nombre = "Papas Fritas",
    Precio = 30
};
//Serializamos en JSON el producto y lo guardamos como un string
string jsonString = JsonSerializer.Serialize(papas);
//Escribimos la cadena que se serializo
Console.WriteLine(jsonString);
//Ahora Deserealizamos la cadena JSNON y creamos un objeto Producto a partir de ella
Producto producto = JsonSerializer.Deserialize<Producto>(jsonString);
//Escribimos el producto que se deserializo
Console.WriteLine($"Nombre: {producto.Nombre} Precio: {producto.Precio}");