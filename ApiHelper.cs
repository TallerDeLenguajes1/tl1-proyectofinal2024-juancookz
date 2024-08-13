using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public static class ApiHelper
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<CuerpoDeRespuestaApi> ObtenerDatosApi()
    {
        string url = "https://api.gameofthronesquotes.xyz/v1/random";

        try
        {
            // Hacer la solicitud a la API
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Leer la respuesta JSON
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserializar la respuesta JSON a un objeto
            CuerpoDeRespuestaApi apiResponse = JsonSerializer.Deserialize<CuerpoDeRespuestaApi>(jsonResponse);

            return apiResponse;
        }
        catch (HttpRequestException e)
        {
            // Manejo de errores
            Console.WriteLine($"Error al hacer la solicitud: {e.Message}");
            return null;
        }
    }
}
// Clase que representa la respuesta de la API
public class CuerpoDeRespuestaApi
{
    [JsonPropertyName("sentence")]
    public string Frase { get; set; }

    [JsonPropertyName("character")]
    public Character Personaje { get; set; }
}

// Clase que representa el personaje en la respuesta de la API
public class Character
{
    [JsonPropertyName("name")]
    public string Nombre { get; set; }
}