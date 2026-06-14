namespace administrador_contenido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BuscarSerie buscar = new BuscarSerie();
            try
            {
                string cadena;
                bool continuar = true, sesion_iniciada=false;
                Usuario usuario_activo = new Usuario();
                while (continuar)
                {
                    if (!sesion_iniciada)
                    {
                        cadena = Utildades.menu( new String[] { "Iniciar Secion", "Crear Usuario", "Salir" });
                        switch (cadena)
                        {
                            case "Iniciar Secion":
                            {
                                sesion_iniciada = Utildades.Iniciar_Sesion(ref usuario_activo);
                                break;
                            }
                            case "Crear Usuario":
                            {
                                sesion_iniciada = Utildades.crear_usuario(ref usuario_activo);
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
                        cadena = Utildades.menu( new String[] { "Buscar pelicula","Buscar serie","Buscar usuario","Ver datos de usuario","Ver publicaciones","Adivinar pelicula","Cerrar secion" });
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
                                //se espera codigo
                                break;
                            }
                        }
                    }
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
                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("holaPEPE");
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