using System;
using System.Collections.Generic;

namespace administrador_contenido
{
    // Clase concreta espejo para que el JsonSerializer no explote
    internal class ResultadoAPI
    {
        public int id { get; set; }
        public string title { get; set; }      // TMDB lo manda solo si es película
        public string name { get; set; }       // TMDB lo manda solo si es serie
        public string overview { get; set; }   // Sinopsis de la película/serie
        public List<int> genre_ids { get; set; }
    }

    internal class TotalContenidos
    {
        public int page { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }

        // La lista mapeada con la clase concreta
        public List<ResultadoAPI> results { get; set; } = new List<ResultadoAPI>();

        // CORREGIDO: Lógica de impresión adaptada a lo que devuelve la API
        public void MostrarDatos(Usuario usuario_activo)
        {
            // Validamos que realmente hayan llegado películas o series
            if (results == null || results.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontraron resultados para mostrar en esta página.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== Mostrando Página {this.page} de {this.total_pages} ===");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------------------");

            foreach (ResultadoAPI res in this.results)
            {
                // PASO CLAVE: Si 'title' viene vacío, es una serie, entonces usamos 'name'
                string tituloFinal = !string.IsNullOrEmpty(res.title) ? res.title : res.name;

                // Si no hay sinopsis, ponemos un texto por defecto para que no quede en blanco
                string sinopsisFinal = !string.IsNullOrEmpty(res.overview)
                    ? res.overview
                    : "Sin sinopsis disponible.";

                // Imprimimos el título destacado en amarillo
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"• Título: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(tituloFinal);

                // Imprimimos la sinopsis resumida
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  Sinopsis: {sinopsisFinal}");
                Console.WriteLine("------------------------------------------------------------------");
            }
            Console.ResetColor();
        }
    }
}
