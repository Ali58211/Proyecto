using System;
using System.Collections.Generic;
using System.Text;

namespace Busqueda
{
    internal interface IAccion
    {
        public void Play();
        public void Pause();
        public void EpAnterior();
        public void EpSiguiente();
    }
}
