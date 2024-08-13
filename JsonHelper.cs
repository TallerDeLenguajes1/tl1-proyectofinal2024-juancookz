using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
class PersonajesJson
{
    public void GuardarPersonajes(List<Personaje> ListaPersonajes, string nombreArchivo)
    {
        //Serializamos la lista de personajes en formato JSON
        string jsonString = JsonSerializer.Serialize(ListaPersonajes);

        //Escribimos el archivo con el nombre indicado y contenido del json
        System.IO.File.WriteAllText(nombreArchivo, jsonString);
    }
    public List<Personaje> LeerPersonajes(string nombreArchivo)
    {
        //Leemos el contenido del archivo en formato JSON
        string jsonString = System.IO.File.ReadAllText(nombreArchivo);

        //Deserealizamos el contenido en formato JSON y lo convertimos a lista de personajes
        List<Personaje> ListaPersonajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);

        return ListaPersonajes;
    }

    public bool ExisteListaPersonajes(string nombreArchivo)
    {
        // intentamos ejecutar el siguiente bloque
        try
        {
            return System.IO.File.Exists(nombreArchivo) && LeerPersonajes(nombreArchivo) != null;
        }
        // si llega a fallar,devolvemos existencia nula
        catch (Exception)
        {
            return false;
        }
    }
}
class HistorialJson
{
    public void GuardarGanador(Personaje personaje, string nombreArchivo)
    {
    }
    public List<Personaje> LeerGanadores(string nombreArchivo)
    {
        return null;
    }
    public bool ExisteListaPersonajes(string nombreArchivo)
    {
        // intentamos ejecutar el siguiente bloque
        try
        {
            return System.IO.File.Exists(nombreArchivo) && LeerGanadores(nombreArchivo) != null;
        }
        // si llega a fallar,devolvemos existencia nula
        catch (Exception)
        {
            return false;
        }
    }

}