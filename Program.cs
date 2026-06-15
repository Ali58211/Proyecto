using System.Text.Json;
using System.Net.Http;

namespace administrador_contenido
{
    internal class Program
    {
        public static string cadena = "";
        public static bool continuar = true;
        public static string[] info;
        public static HttpClient client = new HttpClient();
        public static string apiKey = "f6ea4d5e46440ed50e6316844f6b6f6d";
        static void Main(string[] args)
        {
            //BuscarSerie buscar = new BuscarSerie();
            try
            {
                Utilidades.DescargarGeneros();
                Utilidades.menu_principal();
                    int op,elec;
                    Console.WriteLine("Seleccione el tipo de búsqueda:");
                    Console.WriteLine("1. Buscar serie");
                    Console.WriteLine("2. Buscar Pelicula");
                    while (!int.TryParse(Console.ReadLine(), out elec))
                    {
                        Console.WriteLine("Ingrese un número válido:");
                    }
                    while (elec < 1 || elec > 2)
                    {
                        Console.WriteLine("Opción inválida. Ingrese 1 o 2:");
                        int.TryParse(Console.ReadLine(), out elec);
                    } 
                    switch (elec)
{
    case 1:
        {
            BuscarSerie Serie = new BuscarSerie();

            Console.WriteLine("Ingrese la serie a buscar:");
            string titulo_s = Console.ReadLine();

            string url = $"https://api.themoviedb.org/3/search/tv?query={Uri.EscapeDataString(titulo_s)}&language=es-ES&api_key={apiKey}";

            string json = await client.GetStringAsync(url);

            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var respuesta = JsonSerializer.Deserialize<RespuestaSerie>(json, opciones);

            if (respuesta != null && respuesta.results.Count > 0)
            {
                foreach (var serie in respuesta.results)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Titulo -- {serie.name}");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Fecha de lanzamiento -- {serie.first_air_date}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Descripción -- {serie.overview}");

                    Console.WriteLine("---------------------------");

                }
            }
            else
            {
                Console.WriteLine("No se encontraron series.");
            }

            break;
        }
    case 2:
        {
            BuscarPelicula Pelicula = new BuscarPelicula();
            Console.WriteLine("Ingrese la pelicula a buscar:");
            string titulo_p = Console.ReadLine();

            string url_peli = $"https://api.themoviedb.org/3/search/movie?query={Uri.EscapeDataString(titulo_p)}&language=es-ES&api_key={apiKey}";

            string json_1 = await client.GetStringAsync(url_peli);

            var opciones = new JsonSerializerOptions // var deja que el programa infiera el tipo de dato, en este caso RespuestaPelicula
            {
                PropertyNameCaseInsensitive = true
            };

            var respuesta = JsonSerializer.Deserialize<RespuestaPelicula>(json_1, opciones);

            if (respuesta != null && respuesta.results.Count > 0)
            {
                foreach (var peli in respuesta.results)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Titulo -- {peli.title}");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Fecha de lanzamiento -- {peli.release_date}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Descripción -- {peli.overview}");

                    Console.WriteLine("---------------------------");

                }
            }
            else
            {
                Console.WriteLine("No se encontraron resultados");
            }

            break;
        }
}
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
