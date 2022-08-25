using Biblioteca2022.DATOS;
using Biblioteca2022.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.SERVICIOS
{
    public class LibrosServicios
    {
        private readonly LibrosRepositorio repositorio;

        public LibrosServicios()
        {
            repositorio = new LibrosRepositorio();
        }

        public List<Libro> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int Agregar(Libro Libro)
        {
            try
            {
                return repositorio.Agregar(Libro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Borrar(Libro Libro)
        {
            try
            {
                return repositorio.Borrar(Libro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int Editar(Libro Libro)
        {
            try
            {
                return repositorio.Editar(Libro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
