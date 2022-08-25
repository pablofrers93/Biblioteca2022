using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.ENTIDADES
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public int LibroId{ get; set; }
        public int SocioId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public byte[] RowVersion { get; set; }

        public Libro Libro { get; set; }
        public Usuario Socio { get; set; }
    }
}
