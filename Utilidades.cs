using administrador_contenido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace administrador_contenido
{
    internal class Utilidades
    {
        public static bool Iniciar_Sesion(ref Usuario usuario_activo)
        {
            Program.info = new string[2];
            while (true)
            {
                Program.cadena = Utilidades.menu(new string[] { "Ingresar datos", "Atras" });
                switch (Program.cadena)
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
            Program.info = new string[3];
            while (true)
            {
                Program.cadena = Utilidades.menu(new string[] { "Ingresar datos", "Atras" });
                switch (Program.cadena)
                {
                    case "Ingresar datos":
                    {
                    Program.info = formulario(new string[] { "Ingrese su nombre de usuario: ", "Ingrese su fecha de nacimiento(año/mes/dia): ", "Ingrese su contraseña: " });
                    Program.cadena = Utilidades.menu(new string[] { "Cuenta privada", "Cuenta publica" });
                    switch (Program.cadena)
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
                    while (!DateTime.TryParse(Program.info[1], out fecha_ingresada))
                    {
                        Console.Write("Fecha no valida, reingrese su fecha de nacimiento(año/mes/dia): ");
                        Program.info[1] = Console.ReadLine();
                    }
                    bool existe_usuario = false; // Reiniciamos la bandera en cada intento
                    foreach (Usuario us in Biblioteca.usuarios)
                    {
                        if (us.nombre_usuario == Program.info[0])
                        {
                            Console.WriteLine("El nombre ingresado ya existe");
                            Console.ReadKey();
                            existe_usuario = true;
                        }
                    }
                    if (!existe_usuario)
                    {
                        Usuario usuario_creado = new Usuario(Program.info[0], Program.info[2], fecha_ingresada, estado_previo);
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
            bool sesion_iniciada=false;
            Usuario usuario_activo = new Usuario();
                while (Program.continuar)
                {
                    if (!sesion_iniciada)
                    {
                        Program.cadena = Utilidades.menu( new String[] { "Iniciar Secion", "Crear Usuario", "Salir" });
                        switch (Program.cadena)
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
                                Program.continuar = false;
                                break;
                            }
                        }
                    }
                    else 
                    {
                        Program.cadena = Utilidades.menu( new String[] { "Buscar pelicula","Buscar serie","Buscar usuario","Ver datos de usuario","Ver publicaciones","Adivinar pelicula","Cerrar sesion" });
                        switch (Program.cadena)
                        {
                            case "Buscar pelicula":
                            {
                                Utilidades.Buscar_contenido("pelicula", usuario_activo );
                                Program.continuar = true;
                                break;
                            }
                            case "Buscar serie":
                            {
                                Utilidades.Buscar_contenido("serie", usuario_activo);
                                Program.continuar = true;
                                break;
                            }
                            case "Buscar usuario":
                            {
                                Utilidades.Buscar_usuario();
                                Program.continuar = true;
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

        public static async Task DescargarGeneros()
        {
            string url = $"https://api.themoviedb.org/3/genre/movie/list?api_key={Program.apiKey}&language=es-ES";
            string json = await Program.client.GetStringAsync(url);
            TotalGeneros respuestaGeneros = JsonSerializer.Deserialize<TotalGeneros>(json);
            Dictionary<int, string> ListaGeneros = new();
            foreach (Genero gen in respuestaGeneros.generos)
            {
                ListaGeneros.Add(Genero.id, Genero.name);
            }
        }
        
        public static async Task Buscar_contenido(string tipo, Usuario usuario_activo)
        {
            string camb_pag;
            bool filtro;
            Program.info = new string[1];
            while(Program.continuar)
            {
                Program.cadena = Utilidades.menu( new String[] { $"Buscar {tipo} solo por nombre",$"Buscar {tipo} con filtros","Atras" });
                switch (Program.cadena)
                {
                    case "Buscar solo por nombre":
                    {
                        filtro = false
                        break;
                    }
                    case "Buscar con filtros":
                    {
                        filtro = true
                        break;
                    }
                    case "Atras":
                    {
                        Program.continuar = false;
                        break;
                    }
                }
                Program.info = Utilidades.formulario( new String[] { $"Ingrese el nombre de la {tipo} que desea buscar: " });
                string url_contenido;
                if(tipo == "pelicula")
                {
                    string url_contenido = $"https://api.themoviedb.org/3/search/movie?query={Program.info[0]}&language=es-ES&api_key={Program.apiKey}";
                }
                if(tipo == "serie")
                {
                    string url_contenido = $"https://api.themoviedb.org/3/search/tv?query={Program.info[0]}&language=es-ES&api_key={Program.apiKey}";
                }
                string json = await client.GetStringAsync(url_contenido);
                TotalContenidos respuesta = JsonSerializer.Deserialize<TotalContenidos>(json);
                Console.WriteLine($"Total de resultados: {respuesta.total_results}\n}");
                if(respuesta.total_results>20)
                {
                    int pagina = resultados.page;
                    while(Program.continuar)
                    {
                        respuesta.MostrarDator(usuario_activo);
                        camb_pag = Utilidades.menu( new String[] { "Pagina anterio","Pagina siguiente","Atras" });
                        switch (camb_pag)
                        {
                            case "Pagina anterio":
                            {
                                if(pagina == 1)
                                {
                                    pagina = respuesta.total_pages;
                                }
                                else 
                                {
                                    pagina--;
                                }
                                if(tipo == "pelicula")
                                {
                                    string url_contenido = $"https://api.themoviedb.org/3/search/movie?query={Program.info[0]}&language=es-ES&page={pagina}&api_key={Program.apiKey}";;
                                }
                                if(tipo == "serie")
                                {
                                    string url_contenido = $"https://api.themoviedb.org/3/search/tv?query={Program.info[0]}&language=es-ES&page={pagina}&api_key={Program.apiKey}";;
                                }
                                string json = await client.GetStringAsync(url_contenido);
                                TotalContenidos respuesta = JsonSerializer.Deserialize<TotalContenidos>(json);
                            }
                            case "Pagina siguiente":
                            {
                                if(pagina == respuesta.total_pages)
                                {
                                    pagina = 1;
                                }
                                else 
                                {
                                    pagina++;
                                }
                                if(tipo == "pelicula")
                                {
                                    string url_contenido = $"https://api.themoviedb.org/3/search/movie?query={Program.info[0]}&language=es-ES&page={pagina}&api_key={Program.apiKey}";;
                                }
                                if(tipo == "serie")
                                {
                                    string url_contenido = $"https://api.themoviedb.org/3/search/tv?query={Program.info[0]}&language=es-ES&page={pagina}&api_key={Program.apiKey}";;
                                }
                                string json = await client.GetStringAsync(url_contenido);
                                TotalContenidos respuesta = JsonSerializer.Deserialize<TotalContenidos>(json);
                            }
                            case "Atras":
                            {
                                Program.continuar = false;
                                break;
                            }
                        }
                    }
                    Program.continuar = true;
                }
                else
                {
                    respuesta.MostrarDator(usuario_activo);
                    camb_pag = Utilidades.menu( new String[] { "Atras" });
                }
            }
        }
        public static void Buscar_usuario()
        {
            Program.info = new string[1];
            while(Program.continuar)
            {
                bool usuario_enc = false;
                Program.info = Utilidades.formulario( new String[] { $"Ingrese el nombre del usuario que desea buscar: " });
                foreach (Usuario us in Biblioteca.usuarios)
                {
                    if(us.nombre_usuario == Program.info[0] && us.estado == estado_usuario.publico)
                    {
                        usuario_enc = true;
                        us.MostrarDatosUsuario();
                    }
                    if(usuario_enc == false)
                    {
                        Console.WriteLine("No se encontro ningun usuario");
                    }
                }
                Program.cadena = Utilidades.menu( new String[] { "Atras" });
                if(Program.cadena == "Atras")
                {
                    Program.continuar = false;
                }
            }
        }
    }
}
