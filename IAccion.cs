using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal interface IAccion
    {
        public void Play();
        public void Pause();
        public void EpAnterior();
        public void EpSiguiente();
    }
}
