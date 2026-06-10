using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class Contenido
    {
        private string _sinopsis;

        private Double _puntaje;

        public string overview //sinopsis
        {
            get { return this._sinopsis; }
            set { this._sinopsis = value; }
        }

        public double vote_average //puntaje
        {
            get { return this._puntaje; }
            set { this._puntaje = value; }
        }
    }
}
