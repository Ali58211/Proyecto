using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    enum estado_usuario
    {
        privado,
        publico,
        inexistente
    }
    internal class Usuario
    {
        private string? _nombre_Usuario;
        private string? _clave_usuario;
        private int _edad;

        public Usuario()
        {
            this.Edad = 0;
            this.Clave_usuario =string.Empty;
            this.nombre_usuario = string.Empty;
        }

        public Usuario(string nom, string clave, int ed)
        {
            this.Edad = ed;
            this.Clave_usuario = clave;
            this.nombre_usuario = nom;
        }

        public string nombre_usuario 
        { get {return this._nombre_Usuario; }
          set {this._nombre_Usuario = value; } }

        public string Clave_usuario
        {
            get { return this._clave_usuario; }
            set { this._clave_usuario = value; }
        }

        public int Edad
        {
            get { return this._edad; }
            set { this._edad = value; }
        }

        public void CrearCuenta()
        {
        }

        public void IniciarSesion()
        {
        }
    }
}
