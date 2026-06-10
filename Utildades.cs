using administrador_contenido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace administrador_contenido
{
    internal class Utildades
    {
        static string menu(string[] opciones)
        {

            int indiceSeleccionado = 0;
            ConsoleKeyInfo tecla;
            Console.CursorVisible = false; // Oculta el cursor para mayor prolijidad

            do
            {
                Console.Clear();

                // Muestra las opciones y aplica el efecto
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == indiceSeleccionado)
                    {
                        // Invierte los colores para la opción seleccionada
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        // Colores por defecto para las no seleccionadas
                        Console.ResetColor();
                    }

                    // Dibuja la línea
                    Console.WriteLine(opciones[i]);
                }

                // Captura la tecla
                tecla = Console.ReadKey(true);

                // Cambia el índice según la flecha presionada
                if (tecla.Key == ConsoleKey.UpArrow)
                {
                    indiceSeleccionado--;
                    if (indiceSeleccionado < 0) indiceSeleccionado = opciones.Length - 1;
                }
                else if (tecla.Key == ConsoleKey.DownArrow)
                {
                    indiceSeleccionado++;
                    if (indiceSeleccionado >= opciones.Length) indiceSeleccionado = 0;
                }

            } while (tecla.Key != ConsoleKey.Enter);

            // Restaura los colores originales de la consola
            Console.ResetColor();

            // Retorna la opción seleccionada
            return opciones[indiceSeleccionado];


        }




        /*
        public static int Mostrar()
        {



            
            int opcion;
            string cadena;
            Console.WriteLine("1-Buscar pelicula");
            Console.WriteLine("2-Buscar serie");
            Console.WriteLine("3-Salir");

            cadena = Console.ReadLine();

            while (!int.TryParse(cadena, out opcion))
            {
                Console.WriteLine("reingrese opcion: ");
                cadena = Console.ReadLine();
            }

            return opcion;
        }

        */

    }
}
