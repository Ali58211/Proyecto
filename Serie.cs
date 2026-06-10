using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class Serie : Contenido
    {
        public string? _nombre;

        public string? _fecha_emision;

        public string name
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
       
        public string first_air_date
        {
            get { return this._fecha_emision; }
            set { this._fecha_emision = value; }
        }
       
    }
}
