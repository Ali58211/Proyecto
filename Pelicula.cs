using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class Pelicula : Contenido
    {
        private string _title; //título traducido 
        private string _original_title; //título original 
        private DateTime _release_date; //fecha de estreno 

        public Pelicula() : base()
        {
            this.title = string.Empty;
            this.original_title = string.Empty;
            this.release_date = DateTime.MinValue;
        }

        public Pelicula(bool ad, int[] genID, int i, string tit, string origLang, string origTit, string oview, float popul, DateTime releDate, float votAver, int votCount) : base(ad, genID, i, origLang, oview, popul, votAver, votCount)
        {
            this.title = tit;
            this.original_title = origTit;
            this.release_date = releDate;
        }

        public string title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        public string original_title
        {
            get { return this._original_title; }
            set { this._original_title = value; }
        }

        public DateTime release_date
        {
            get { return this._release_date; }
            set { this._release_date = value; }
        }

        public void MostrarDatos()
        {
            Console.Write($"Nombre de la pelicula: {this.title} ({this.original_title})\nFecha de estreno: {this.releace_date}\nClasificacion: ");
            if(this.adult)
            {
                Console.WriteLine("Solo para adultos");
            }
            else 
            {
                Console.WriteLine("Apta para todo público");
            }
            Console.Write($"Idioma original: {this.original_language}\nGéneros: ");
            foreach(int idGenero in this.genre_ids)
            {
                if(ListaGeneros.ContainsKey(idGenero))
                {
                    Console.Write($"{ListaGeneros[idGenero]} ");
                }
            }
            Console.WriteLine($"Calificación promedio: {this.vote_average}\nVotos totales: {this.vote_count}\nIndice de popularidad: {this.popularity}\nSinopsis: {this.overview}");
        }
    }
}
