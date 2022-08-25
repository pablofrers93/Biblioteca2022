using Biblioteca2022.DATOS;
using Biblioteca2022.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.SERVICIOS
{
    public class UsuariosServicios
    {
        private readonly UsuariosRepositorio repositorio;

        public UsuariosServicios()
        {
            repositorio = new UsuariosRepositorio();
        }

        public List<Usuario> GetLista()
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