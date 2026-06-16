using System.Text.Json;
using System.Net.Http;

namespace administrador_contenido
{
    internal class Program
    {
        public static string cadena = "";
        public static bool continuar = true;
        public static string[] info;
        public static HttpClient client = new HttpClient();
        public static string apiKey = "f6ea4d5e46440ed50e6316844f6b6f6d";
        static void Main(string[] args)
        {
            try
            {
                Utilidades.DescargarGeneros();
                Utilidades.menu_principal();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
