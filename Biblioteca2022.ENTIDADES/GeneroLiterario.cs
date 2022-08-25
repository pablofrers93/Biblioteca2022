using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.ENTIDADES
{
    public class GeneroLiterario
    {
        public int GeneroLiterarioId { get; set; }
        public string Descripcion { get; set; }
        public byte[] RowVersion { get; set; }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
