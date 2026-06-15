using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class BuscarSerie : IAccion
    {
        public BuscarSerie() 
        {
            this.Temporada = 0;
            this.Episodio = string.Empty;
        }
        public BuscarSerie(int temporada, string episodio)
        {
            this.Temporada = temporada;
            this.Episodio = episodio;
        }
        public int Temporada { get; set; }
        public string Episodio { get; set; }
        
        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void EpAnterior()
        {
            throw new NotImplementedException();
        }

        public void EpSiguiente()
        {
            throw new NotImplementedException();
        }
    }
    public class RespuestaSerie
    {
        public List<Serie> results { get; set; }
    }

    public class Serie
    {
        public string name { get; set; }
        public string overview { get; set; }
        public string first_air_date { get; set; }
    }
}
