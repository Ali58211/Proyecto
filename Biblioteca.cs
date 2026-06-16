using System;
using System.Collections.Generic;

namespace administrador_contenido
{
    internal class Biblioteca
    {
        // Atributos privados encapsulados (Pauta N° 3)
        private List<Usuario> _usuarios;
        private List<Publicacion> _publicaciones;

        // Constructor: Inicializa las colecciones en memoria RAM (Pauta N° 4)
        public Biblioteca()
        {
            this._usuarios = new List<Usuario>();
            this._publicaciones = new List<Publicacion>();
        }

        // Propiedades públicas con métodos de acceso obligatorios para el Serializer
        public List<Usuario> usuarios
        {
            get { return this._usuarios; }
            set { this._usuarios = value; }
        }

        public List<Publicacion> publicaciones
        {
            get { return this._publicaciones; }
            set { this._publicaciones = value; }
        }

        // Método de instancia para añadir elementos de forma controlada
        public void agregar_usuario(Usuario us)
        {
            if (us != null)
            {
                this._usuarios.Add(us);
            }
        }
        // Método de instancia para añadir elementos de forma controlada
        public void agregar_publicacion(Publicacion pu)
        {
            if (pu != null)
            {
                this.publicaciones.Add(pu);
            }
        }
    }
}
