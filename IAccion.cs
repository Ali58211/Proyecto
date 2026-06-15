using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal interface IAccion
    {
        public class Play
        { 
            void Play();
        }
         public class Pause
        { 
        public void Pause();
        }
        
        public class Siguiente
        {
        public void EpAnterior();
        public void EpSiguiente();
        }

    
    }
}
