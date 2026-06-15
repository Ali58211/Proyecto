using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
  internal class Serie : Contenido
  {
    private string[] _origin_country; //país o países donde se produjo originalmente la serie
    private string _original_name; //nombre original 
    private DateTime _first_air_date; //fecha de estreno del primer episodio
    private string _name; //nombre original 

    public Serie() : base()
    {
      this.origin_country = new string[] { };
      this.original_name = string.Empty;
      this.first_air_date = DateTime.MinValue;
      this.name = string.Empty;
    }

    public Serie(bool ad, int[] genID, int i, string[] origCountry, string origLang, string origName, string oview, float popul, DateTime firstAir, string nom, float votAver, int votCount) : base(ad, genID, i, origLang, oview, popul, votAver, votCount)
    {
      this.origin_country = origCountry;
      this.original_name = origName;
      this.first_air_date = firstAir;
      this.name = nom;
    }

    public string[] origin_country
    {
      get { return this._origin_country; }
      set { this._origin_country = value; }
    }

    public string original_name
    {
      get { return this._original_name; }
      set { this._original_name = value; }
    }

    public DateTime first_air_date
    {
      get { return this._first_air_date; }
      set { this._first_air_date = value; }
    }

    public string name
    {
      get { return this._name; }
      set { this._name = value; }
    }

    public override void MostrarDatos()
    {
      Console.Write($"Nombre de la pelicula: {this.name} ({this.original_name})\nFecha de estreno del primer episodio: {this.first_air_date}\nClasificacion: ");
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
