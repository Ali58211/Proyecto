using System;
using System.Collections.Generic;
using System.Text;

namespace administrador_contenido
{
    internal class TotalPeliculas
    {
        private int _page; //pagina actual
        private List<Pelicula> _results; //pelicuas
        private int _total_pages; //total de paginas
        private int _total_results; //total de peliculas

        public TotalPeliculas()
        {
            this.page = 0;
            this.results = new List<Pelicula>();
            this.total_pages = 0;
            this.total_results = 0;
        }

        public TotalPeliculas(int pag, List<Pelicula> res, int totpag, int totres)
        {
            this.page = pag;
            this.results = res;
            this.total_pages = totpag;
            this.total_results = totres;
        }

        public int page 
        {
            get { return this._page; }
            set { this._page = value; }
        }
        public List<Pelicula> results
        {
            get { return this._results; }
            set { this._results = value; }
        }
        public int total_pages 
        {
            get { return this._total_pages; }
            set { this._total_pages = value; }
        }
        public int total_results 
        {
            get { return this._total_results; }
            set { this._total_results = value; }
        }
        public void MostrarDatos()
        {
            Console.WriteLine($"Total de resultados: {this.total_results}\n}");
            foreach(Pelicula pel in this.results)
            {
                pel.MostrarDatos();   
                Console.WriteLine();     
            }
        }
    }
}
