using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class TotalGeneros
    {
        private Genero[] _generos;

        public TotalGeneros()
        {
            this.genero = new Genero[] {};
        }

        public Genero[] genero
        {
            get { return this._generos; }
            set { this._generos = value; }
        }
    }
}
