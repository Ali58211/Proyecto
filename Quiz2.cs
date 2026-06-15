using System.Text.Json;
using static Quiz2.Pelicula;

namespace Quiz2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string apiKey = "f6ea4d5e46440ed50e6316844f6b6f6d";

            // 1.Traer una peli popular al azar
            string urlPopulares = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=es-AR&with_original_language=en";
            string jsonPopulares = await client.GetStringAsync(urlPopulares);
            BusquedaPelicula populares = JsonSerializer.Deserialize<BusquedaPelicula>(jsonPopulares);

            Random rand = new Random();
            int indice = rand.Next(populares.results.Count);
            ResultadoPelicula peliculaElegida = populares.results[indice];

            // 2.Traer lista de generos
            string urlGeneros = $"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}&language=es-AR";
            string jsonGeneros = await client.GetStringAsync(urlGeneros);
            ListaGeneros generos = JsonSerializer.Deserialize<ListaGeneros>(jsonGeneros);

            // traducir genre_ids a nombre
            string nombreGenero = "Desconocido";
            if (peliculaElegida.genre_ids.Length > 0)
            {
                int idGenero = peliculaElegida.genre_ids[0];
                Genero g = generos.genres.Find(x => x.id == idGenero);
                if (g != null) nombreGenero = g.name;
            }

            // 3.Traer actor principal
            string urlCreditos = $"https://api.themoviedb.org/3/movie/{peliculaElegida.id}/credits?api_key={apiKey}&language=es-AR";
            string jsonCreditos = await client.GetStringAsync(urlCreditos);
            Creditos creditos = JsonSerializer.Deserialize<Creditos>(jsonCreditos);

            string actorYPersonaje = "Desconocido";
            if (creditos.cast.Count > 0)
            {
                CastMember actorPrincipal = creditos.cast[0];
                actorYPersonaje = $"{actorPrincipal.name} como {actorPrincipal.character}";
            }

            // 4. Armar las pistas
            string overviewRecortada = peliculaElegida.overview.Length > 50
                ? peliculaElegida.overview.Substring(0, 70) + "..." : peliculaElegida.overview;

            string[] pistas = {
                overviewRecortada,
                $"Anio de lanzamiento: {peliculaElegida.release_date.Substring(0, 4)}",
                $"genero: {nombreGenero}",
                $"actor: {actorYPersonaje}"
            };

            //5 jUEGO DEL AHORCADO
            string palabra = peliculaElegida.title.ToUpper();
            char[] letras = palabra.ToCharArray();
            int longitud = letras.Length;
            int[] adivinadas = new int[longitud];
            int intentos = 4;
            int contador = 0;
            bool juegoActivo = true;

            Console.WriteLine("ahorcado PELIS\n");

            do
            {
                int letrasEncontradas = 0;

                //mostrar progreso
                for (int h = 0; h < longitud; h++)
                {
                    if (adivinadas[h] == 1)
                    {
                        Console.Write(" " + letras[h] + " ");
                        letrasEncontradas++;
                    }
                    else if (letras[h] == ' ')
                    {
                        Console.Write("   ");
                        letrasEncontradas++; //los espacios no cuentan como letra a adivinar
                    }
                    else
                    {
                        Console.Write(" _ ");
                    }
                }
                Console.WriteLine();

                if (letrasEncontradas == longitud)
                {
                    juegoActivo = false;
                    Console.WriteLine($"felicitaciones la peli era: {peliculaElegida.title}");
                }
                else
                {
                    Console.WriteLine($"Vidas restantes: {intentos}");

                    if (contador < pistas.Length)
                    {
                        Console.WriteLine($"Pista {contador + 1}: {pistas[contador]}");
                    }

                    Console.WriteLine("ingrese una letra: ");
                    char letra = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                    Console.Clear();

                    bool acerto = false;
                    for (int i = 0; i < longitud; i++)
                    {
                        if (letras[i] == letra)
                        {
                            adivinadas[i] = 1;
                            acerto = true;
                        }
                    }

                    if (!acerto)
                    {
                        intentos--;
                        contador++;
                    }

                    if (intentos == 0)
                    {
                        juegoActivo = false;
                        Console.WriteLine($"GAME OVER. La pelicula era: {peliculaElegida.title}");
                    }
                }

            } while (juegoActivo);
        }
    }
}
