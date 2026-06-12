namespace Busqueda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BuscarSerie buscar = new BuscarSerie();
            string cadena;
            try
            {
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
