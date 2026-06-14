using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class Pelicula
    {
            private bool _adult; //indica si la pelicula es para adultos
            private int?[] _genre_ids;  //lista de IDs de géneros
            private int _id; //ID único de la película en TMDb
            private string _title; //título traducido -
            private string _original_language; //idioma original
            private string _original_title; //título original -
            private string _overview; //sinopsis
            private float _popularity; //popularidad calculada por TMDb
            private string _release_date; //fecha de estreno -
            private float _vote_average; //promedio de puntuación
            private int _vote_count; //cantidad de votos recibidos

            public Pelicula()
            {
                this.adult = false;
                this.genre_ids = new int[] {};
                this.id = 0;
                this.title = string.Empty;
                this.original_language = string.Empty;
                this.original_title = string.Empty;
                this.overview = string.Empty;
                this.popularity = 0;
                this.release_date = string.Empty;
                this.vote_average = 0;
                this.vote_count = 0;
            }
            public Pelicula(bool ad,int[] genID,int i,string tit,string origLang,string origTit,string oview,float popul,string releDate,float votAver,int votCount)
            {
                this.adult = ad;
                this.genre_ids = genID;
                this.id = i;
                this.title = tit;
                this.original_language = origLang;
                this.original_title = origTit;
                this.overview = oview;
                this.popularity = popul;
                this.release_date = releDate;
                this.vote_average = votAver;
                this.vote_count = votCount;
            }

            public bool adult
            {
                get { return this._adult; }
                set { this._adult = value; }
            }
            public int?[] genre_ids 
            {
                get { return this._genre_ids; }
                set { this._genre_ids = value; }
            }
            public int id 
            {
                get { return this._id; }
                set { this._id = value; }
            }
            public string title 
            {
                get { return this._title; }
                set { this._title = value; }
            }
            public string original_language 
            {
                get { return this._original_language; }
                set { this._original_language = value; }
            }
            public string original_title 
            {
                get { return this._original_title; }
                set { this._original_title = value; }
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
            public string release_date 
            {
                get { return this._release_date; }
                set { this._release_date = value; }
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
                Console.Write("Géneros: ");
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
