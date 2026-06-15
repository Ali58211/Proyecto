using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal abstract class Contenido
    {
        private bool _adult; //indica si la serie o pelicula es para adultos
        private int[] _genre_ids; //lista de IDs de géneros
        private int _id; //ID único de la serie o pelicula en TMDb
        private string _original_language; //idioma original
        private string _overview; //sinopsis
        private float _popularity; //popularidad calculada por TMDb
        private float _vote_average; //promedio de puntuación
        private int _vote_count; //cantidad de votos recibidos

        public Contenido()
        {
            this.adult = false;
            this.genre_ids = new int[] { };
            this.id = 0;
            this.original_language = string.Empty;
            this.overview = string.Empty;
            this.popularity = 0;
            this.vote_average = 0;
            this.vote_count = 0;
        }

        public Contenido(bool ad, int[] genID, int i, string origLang, string oview, float popul, float votAver, int votCount)
        {
            this.adult = ad;
            this.genre_ids = genID;
            this.id = i;
            this.original_language = origLang;
            this.overview = oview;
            this.popularity = popul;
            this.vote_average = votAver;
            this.vote_count = votCount;
        }

        public bool adult
        {
            get { return this._adult; }
            set { this._adult = value; }
        }

        public int[] genre_ids
        {
            get { return this._genre_ids; }
            set { this._genre_ids = value; }
        }

        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string original_language
        {
            get { return this._original_language; }
            set { this._original_language = value; }
        }

        public string overview
        {
            get { return this._overview; }
            set { this._overview = value; }
        }

        public float popularity
        {
            get { return this._popularity; }
            set { this._popularity = value; }
        }

        public float vote_average
        {
            get { return this._vote_average; }
            set { this._vote_average = value; }
        }

        public int vote_count
        {
            get { return this._vote_count; }
            set { this._vote_count = value; }
        }

        public abstract void MostrarDatos();
    }
}
