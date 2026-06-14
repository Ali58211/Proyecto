using administrador_contenido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace administrador_contenido
{
    internal class Utilidades
    {
        public static bool Iniciar_Sesion(ref Usuario usuario_activo)
        {
            string[] info = new string[2];
            while (true)
            {
                cadena = Utilidades.menu(new string[] { "Ingresar datos", "Atras" });
                switch (cadena)
                {
                    case "Ingresar datos":
                    {
                    info = formulario(new string[] { "Ingrese su nombre de usuario: ", "Ingrese su contraseña: " });
                    foreach (Usuario us in Biblioteca.usuarios)
                    {
                        if (us.nombre_usuario == info[0] && us.Clave_usuario == info[1])
                        {
                            usuario_activo = us;
                            return true;
                        }
                    }
                    }
                    Console.WriteLine("Contraseña o nombre de usuario incorrectos");
                    Console.ReadKey();
                    break; // Necesario para no saltar al siguiente case
                    case "Atras":
                    return false;
                }
            }
        }
        public static bool crear_usuario(ref Usuario usuario_activo)
        {
            estado_usuario estado_previo;
            DateTime fecha_ingresada;
            string[] info = new string[3];
            while (true)
            {
                cadena = Utilidades.menu(new string[] { "Ingresar datos", "Atras" });
                switch (cadena)
                {
                    case "Ingresar datos":
                    {
                    info = formulario(new string[] { "Ingrese su nombre de usuario: ", "Ingrese su fecha de nacimiento(año/mes/dia): ", "Ingrese su contraseña: " });
                    cadena = Utilidades.menu(new string[] { "Cuenta privada", "Cuenta publica" });
                    switch (cadena)
                    {
                        case "Cuenta privada":
                        {
                            estado_previo = estado_usuario.privado
                            break;
                        }
                        case "Cuenta publica":
                        {
                            estado_previo = estado_usuario.publico
                            break;
                        }
                    }
                    while (!DateTime.TryParse(info[1], out fecha_ingresada))
                    {
                        Console.Write("Fecha no valida, reingrese su fecha de nacimiento(año/mes/dia): ");
                        info[1] = Console.ReadLine();
                    }
                    bool existe_usuario = false; // Reiniciamos la bandera en cada intento
                    foreach (Usuario us in Biblioteca.usuarios)
                    {
                        if (us.nombre_usuario == info[0])
                        {
                            Console.WriteLine("El nombre ingresado ya existe");
                            Console.ReadKey();
                            existe_usuario = true;
                        }
                    }
                    if (!existe_usuario)
                    {
                        Usuario usuario_creado = new Usuario(info[0], info[2], fecha_ingresada, estado_previo);
                        Biblioteca.agregar_usuario(usuario_creado);
                        usuario_activo = usuario_creado;
                        Console.WriteLine("Usuario creado con éxito.");
                        Console.ReadKey();
                        return true; // Puedes retornar true o usar break; para volver al menú
                    }
                    break;
                    }
                    case "Atras":
                    return false;
                }
            }
        }
        public static string[] formulario(string[] info)
        {
        string[] resultados = new string[info.Length];
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
                        // Solo cambia el color de la letra a amarillo para la opción seleccionada
                        Console.ForegroundColor = ConsoleColor.Yellow;
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
        public static void menu_principal()
        {
            bool continuar = true, sesion_iniciada=false;
            Usuario usuario_activo = new Usuario();
                while (continuar)
                {
                    if (!sesion_iniciada)
                    {
                        cadena = Utilidades.menu( new String[] { "Iniciar Secion", "Crear Usuario", "Salir" });
                        switch (cadena)
                        {
                            case "Iniciar Secion":
                            {
                                sesion_iniciada = Utilidades.Iniciar_Sesion(ref usuario_activo);
                                break;
                            }
                            case "Crear Usuario":
                            {
                                sesion_iniciada = Utilidades.crear_usuario(ref usuario_activo);
                                break;
                            }
                            case "Salir":
                            {
                                continuar = false;
                                break;
                            }
                        }
                    }
                    else 
                    {
                        cadena = Utilidades.menu( new String[] { "Buscar pelicula","Buscar serie","Buscar usuario","Ver datos de usuario","Ver publicaciones","Adivinar pelicula","Cerrar sesion" });
                        switch (cadena)
                        {
                            case "Buscar pelicula":
                            {
                                //se espera codigo
                                break;
                            }
                            case "Buscar serie":
                            {
                                //se espera codigo
                                break;
                            }
                            case "Buscar usuario":
                            {
                                //se espera codigo
                                break;
                            }
                            case "Ver publicaciones":
                            {
                                //se espera codigo
                                break;
                            }
                            case "Adivinar pelicula":
                            {
                                //se espera codigo
                                break;
                            }
                            case "Cerrar secion":
                            {
                                Console.WriteLine("Se a cerrado sesion");
                                sesion_iniciada=false;
                                break;
                            }
                        }
                    }
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
