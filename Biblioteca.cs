using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal static class Biblioteca
    {
        private static List<Usuario> _usuarios=new List<Usuario>();
        public List<Publicacion> publicaciones { get; set; } = new List<Publicacion>();

        public static void agregar_usuario(Usuario us)
        {
            _usuarios.Add(us);
        }
        public static List<Usuario> usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
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
