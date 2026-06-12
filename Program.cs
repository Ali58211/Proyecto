using System.Collections;
using System.Text.Json;

namespace administrador_contenido
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            //Manu
            string cadena;
            bool continuar=true,sesion_iniciada;
            Usuario usuario_activo = new Usuario();
            while(continuar)
            {
                cadena=Utilidades.menu("Iniciar Secion","Crear Usuario","Salir");
                switch(cadena)
                {
                    case"Iniciar Secion":
                    {
                        sesion_iniciada = Utildades.Iniciar_Sesion(ref usuario_activo);
                        break;
                    }
                    case"Crear Usuario":
                    {
                        //se espera codigo
                        break;
                    }
                    case"Salir":
                    {
                        continuar=false;
                        break;
                    }
                }
            }
            //PROBLEMA: VER COMO EVITAR LA COINCIDENCIA
            try { 
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




                int opcion;

                /*do
                {
                    opcion = Menu.Mostrar();

                    switch (opcion)
                    {
                        case 1:
                            await Pelicula.BusquedaPelicula();
                            break;

                        case 2:
                            await Serie.Buscar();
                            break;

                        case 3:
                            Console.WriteLine("Fin del programa");
                            break;

                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                    }

                } while (opcion != 3);
                */


                if (respuesta != null)
            {
                
                foreach (Pelicula p in respuesta.results)
                {
                    Console.WriteLine($"Título pelicula: {p.title}");
                    //Console.WriteLine($"Fecha: {p.release_date}");
                    //Console.WriteLine($"Puntaje: {p.vote_average}");
                    Console.WriteLine($"sinopsis: {p.overview}");
                    Console.WriteLine();
                }
                foreach (Serie s in respuesta2.results)
                {
                    Console.WriteLine($"Título serie: {s.name}");
                    //Console.WriteLine($"Fecha: {p.release_date}");
                    //Console.WriteLine($"Puntaje: {p.vote_average}");
                    Console.WriteLine($"sinopsis: {s.overview}");
                    Console.WriteLine();
                }
            }

                }
            catch(Exception ex)
            {
                Console.WriteLine($"Se ha presentado el siguiente error: {ex.Message}");
            }
            Console.ReadKey();

        }

    }
}
