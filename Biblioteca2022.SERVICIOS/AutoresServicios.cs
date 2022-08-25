using Biblioteca2022.DATOS;
using Biblioteca2022.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.SERVICIOS
{
    public class AutoresServicios
    {
        private readonly AutoresRepositorio repositorio;

        public AutoresServicios()
        {
            repositorio = new AutoresRepositorio();
        }

        public List<Autor> GetLista()
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
    }
}