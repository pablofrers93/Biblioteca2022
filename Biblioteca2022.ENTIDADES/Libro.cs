using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.ENTIDADES
{
    public class Libro:ICloneable
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public int Ejemplares { get; set; }
        public int GeneroId { get; set; }
        public int IdiomaId { get; set; }
        public int EditorialId { get; set; }
        public decimal Precio { get; set; }
        public byte[] RowVersion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Autor Autor { get; set; }
        public GeneroLiterario Genero { get; set; }
        public Idioma Idioma { get; set; }
        public Editorial Editorial { get; set; }
    }
}
