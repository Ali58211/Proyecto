using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace administrador_contenido
{
    internal async Task class BuscarPelicula
    
{
  
        public static void BuscarPorTitulo(List<Pelicula> peliculas, string titulo)
        {
            foreach (Pelicula pelicula in peliculas)
            {
                if (pelicula.title.ToLower().Contains(titulo.ToLower()))
                {
                    MostrarPelicula(pelicula);
                }
            }
        }

      
        

        public static void BuscarPorFecha(List<Pelicula> peliculas, DateTime fecha)
        {
            foreach (Pelicula pelicula in peliculas)
            {
                if (pelicula.release_date.Date == fecha.Date)
                {
                    MostrarPelicula(pelicula);
                }
            }
        }

        private static void MostrarPelicula(Pelicula pelicula)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Título: {pelicula.title}");
            Console.WriteLine($"Fecha estreno: {pelicula.release_date:dd/MM/yyyy}");
        }
    }
}
       
        
    }
}
