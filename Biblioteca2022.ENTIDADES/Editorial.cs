using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.ENTIDADES
{
    public class Editorial:ICloneable
    {
        public int EditorialId { get; set; }
        public string NombreEditorial { get; set; }
        public byte[] RowVersion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return this.NombreEditorial;
        }
    }
}
