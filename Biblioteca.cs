using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class Biblioteca
    {
        public static List<Usuario> usuarios { get; set; }
        
        public static void agregar_usuario(Usuario us)
        {
            this.usuarios.add(us);
        }
        //relacion agregacion
        public void datos(Serie a, Pelicula b)
        {
        }

        public void buscador()
        {

        }
    }
}
