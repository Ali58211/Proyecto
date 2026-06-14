using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class TotalGeneros
    {
        private Genero[] _generos;

        public ListaGeneros()
        {
            this.generos = new Generos[] {};
        }

        public Genero[] generos
        {
            get { return this._generos; }
            set { this._generos = value; }
        }
    }
}