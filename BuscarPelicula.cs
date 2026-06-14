using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace administrador_contenido
{
    internal async Task class BuscarPelicula
    {
        HttpClient client = new HttpClient();
        string apiKey = "f6ea4d5e46440ed50e6316844f6b6f6d";

        string titulo_p = "spider man";
        string titulo_s = "hora de aventura";
        string url_peli = $"https://api.themoviedb.org/3/search/movie?query={titulo_p}&language=es-ES&api_key={apiKey}";
        string url_serie = $"https://api.themoviedb.org/3/search/tv?query={titulo_s}&language=es-ES&api_key={apiKey}";

        string json_1 = await client.GetStringAsync(url_peli);
        string json_2 = await client.GetStringAsync(url_serie);

        busquedaPelicula respuesta = JsonSerializer.Deserialize<busquedaPelicula>(json_1);
        busquedaSerie respuesta2 = JsonSerializer.Deserialize<busquedaSerie>(json_2);
    }
}
