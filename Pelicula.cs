using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class Pelicula : Contenido
    {
        private string? _titulo;
        private string? _fecha;

        public string title 
        {   get { return this._titulo; }
            set { this._titulo = value ;} }
      

        public string release_date
        {
            get { return this._fecha; }
            set { this._fecha = value; }
        }
       


    }
}
