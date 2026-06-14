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
        private DateTime _fechaNacimiento;
        private estado_usuario _estado;

        public Usuario()
        {
            this.Clave_usuario = string.Empty;
            this.nombre_usuario = string.Empty;
            this.estado = estado_usuario.inexistente;
            this.FechaNacimiento = DateTime.Now;
        }

        public Usuario(string nom, string clave, DateTime fechaNac, estado_usuario est)
        {
            this.Clave_usuario = clave;
            this.nombre_usuario = nom;
            this.FechaNacimiento = fechaNac;
            this.estado = est;
        }

        public string nombre_usuario
        {
            get { return this._nombre_Usuario; }
            set { this._nombre_Usuario = value; }
        }

        public string Clave_usuario
        {
            get { return this._clave_usuario; }
            set { this._clave_usuario = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return this._fechaNacimiento; }
            set { this._fechaNacimiento = value; }
        }

        // Propiedad de solo lectura
        public int Edad
        {
            get
            {
                int edad = DateTime.Now.Year - FechaNacimiento.Year;

                if (DateTime.Now < FechaNacimiento.AddYears(edad))
                {
                    edad--;
                }

                return edad;
            }
        }

        public estado_usuario estado
        {
            get { return this._estado; }
            set { this._estado = value; }
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre de usuario: {nombre_usuario}\nClave: {Clave_usuario}\nFecha de nacimiento: {FechaNacimiento:dd/MM/yyyy}\nEdad: {Edad}\nEstado: {estado}");
        }

        public void CambiarDatos()
        {
            //se cambiara proximamente
            String cadena;
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
    }
}