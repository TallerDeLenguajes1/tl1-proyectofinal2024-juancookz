﻿using System;
using System.Text.Json;
using System.Collections.Generic;
class PersonajesJson
{
    public void GuardarPersonajes(List<Personaje> ListaPersonajes, string nombreArchivo)
    {
    }
    public List<Personaje> LeerPersonajes(string nombreArchivo)

    {

        /*
        List<Personaje> ListaPersonajes;
        */
        return null;
    }
    public void Prueba()
    {
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
    }


}