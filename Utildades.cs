using administrador_contenido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace administrador_contenido
{
    internal class Utildades
    {
        public static bool Iniciar_Sesion(ref Usuario usuario_activo)
        {
            string cad;
            string[] info = new string[];
-           while(true)
            {
                cad=Utilidades.menu("Ingresar datos","Atras");
                switch(cad)
                {
                    case"Ingresar datos":
                    {
                        info = formulario("Ingrese su nombre de usuario: ","Ingrese su contraseña: ");
                        foreach(Usuario us in Biblioteca.usuarios)
                        {
                            if (us.nombre_usuario==info[0] && us.Clave_usuario==info[1])
                            {
                                usuario_activo=us;
                                return true;
                            }
                        }
                        Console.WriteLine("Contraseña o nombre de usuario incorrectos");
                    }
                    case"Atras":
                    {
                        return false;
                    }
                }
            }
        }
        public static bool crear_usuario(ref Usuario usuario_activo)
        {
            string cad;
            int edad_ingresada;
            string[] info = new string[];
            bool existe_usuario=false;
-           while(true)
            {
                cad=Utilidades.menu("Ingresar datos","Atras");
                switch(cad)
                {
                    case"Ingresar datos":
                    {
                        info = formulario("Ingrese su nombre de usuario: ","Ingrese su edad: ","Ingrese su contraseña: ");
                        while(!int.tryParce(info[1], out edad_ingresada))
                        {
                            Console.White("Edad no numerica, reingrese su edad: ");
                            info[1]=Console.ReadLine();
                        }
                        foreach(Usuario us in Biblioteca.usuarios)
                        {
                            if (us.nombre_usuario==info[0])
                            {
                                Console.WriteLine("El nombre ingresado ya existe");
                                existe_usuario=true;
                            }
                        }
                        if(!existe_usuario)
                        {
                            Biblioteca.agregar_usuario(new Usuario(info[0],info[2].info[1]));
                        }
                    }
                    case"Atras":
                    {
                        return false;
                    }
                }
            }
        }
        public static string[] formulario(string[] info,)
        {
            string[] resultados = new string[];
            for (int i = 0; i < info.Length; i++)
            {
                Console.Write(info[i]);
                resultados[i] = Console.ReadLine();
            }
            return resultados;
        }
        public static string menu(string[] opciones)
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
