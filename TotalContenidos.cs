using System;
using System.Collections.Generic;

namespace administrador_contenido
{
    internal class TotalContenidos
    {
        public int page { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }

        // CORREGIDO: Ahora la lista es directamente de tu clase base Contenido
        public List<Contenido> results { get; set; } = new List<Contenido>();

        public void MostrarDatos(Usuario usuario_activo)
        {
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

            foreach (Contenido item in this.results)
            {
                Contenido objetoPolimorfico;

                // Si la API nos devolvió la propiedad 'title', instanciamos tu clase hija real Pelicula
                if (!string.IsNullOrEmpty(item.title))
                {
                    objetoPolimorfico = new Pelicula
                    {
                        id = item.id,
                        title = item.title,
                        overview = item.overview,
                        genre_ids = item.genre_ids
                    };
                }
                else // Si no tiene 'title', asumimos que es una Serie real
                {
                    objetoPolimorfico = new Serie
                    {
                        id = item.id,
                        name = item.name,
                        overview = item.overview,
                        genre_ids = item.genre_ids
                    };
                }

                // ¡LLAMADA POLIMÓRFICA EXIGIDA POR LA CÁTEDRA!
                // C# va a ejecutar el MostrarDatos() que está adentro de Pelicula.cs o Serie.cs
                objetoPolimorfico.MostrarDatos();
            }
        }
    }
}
