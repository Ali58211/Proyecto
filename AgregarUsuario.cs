using System;
using System.IO;
using System.Text.Json;

namespace administrador_contenido
{
    internal static class GestionUsuarios
    {
        const string path = "usuarios.json";

        public static void Ejecutar()
        {
            string cadena;
            int oper;

            // Cargar la biblioteca desde el JSON
            Biblioteca bib = new Biblioteca();
            if (File.Exists(path))
            {
                cadena = File.ReadAllText(path);
                bib = JsonSerializer.Deserialize<Biblioteca>(cadena);
            }

            Console.WriteLine("Ingrese la operacion a realizar: 1.Listar / 2.Agregar");
            cadena = Console.ReadLine();
            while (!int.TryParse(cadena, out oper))
            {
                Console.WriteLine("Ingrese la operacion a realizar: 1.Listar / 2.Agregar");
                cadena = Console.ReadLine();
            }

            switch (oper)
            {
                case 1:
                {
                    Console.WriteLine("--------------------------------");
                    foreach (Usuario us in bib.usuarios)
                    {
                        Console.WriteLine($"{us.nombre_usuario} - Estado: {us.estado}");
                    }
                    break;
                }

                case 2:
                {
                    string nombre, clave;
                    DateTime fechaNac;
                    estado_usuario estado;

                    Console.WriteLine("Nombre de usuario");
                    nombre = Console.ReadLine();
                    while (string.IsNullOrEmpty(nombre))
                    {
                        Console.WriteLine("Nombre...reintentar");
                        nombre = Console.ReadLine();
                    }

                    Console.WriteLine("Clave");
                    clave = Console.ReadLine();
                    while (string.IsNullOrEmpty(clave))
                    {
                        Console.WriteLine("Clave...reintentar");
                        clave = Console.ReadLine();
                    }

                    Console.WriteLine("Fecha de nacimiento (yyyy-MM-dd)");
                    cadena = Console.ReadLine();
                    while (!DateTime.TryParse(cadena, out fechaNac))
                    {
                        Console.WriteLine("Fecha...reintentar");
                        cadena = Console.ReadLine();
                    }

                    Console.WriteLine("Estado: 0-privado / 1-publico");
                    cadena = Console.ReadLine();
                    while (!int.TryParse(cadena, out int est) || (est != 0 && est != 1))
                    {
                        Console.WriteLine("Estado...reintentar");
                        cadena = Console.ReadLine();
                    }
                    estado = (estado_usuario)int.Parse(cadena);

                    Usuario nuevoUsuario = new Usuario(nombre, clave, fechaNac, estado);
                    bib.usuarios.Add(nuevoUsuario);

                    string convertidoAJson = JsonSerializer.Serialize(bib, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(path, convertidoAJson);

                    Console.WriteLine("Usuario agregado con exito.");
                    break;
                }

                default:
                {
                    Console.WriteLine("Operacion no valida");
                    break;
                }
            }
        }
    }
}
