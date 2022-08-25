using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.ENTIDADES
{
    public class Usuario:ICloneable
    {
        public int SocioId { get; set; }
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public int CodPostal { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNac { get; set; }
        public bool Sancionado { get; set; }
        public byte[] RowVersion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
