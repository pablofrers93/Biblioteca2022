using Biblioteca2022.ENTIDADES;
using NuevaAppComercial2022.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2022.DATOS
{
    public class UsuariosRepositorio
    {
        private readonly ConexionBd conexionBd;

        public UsuariosRepositorio()
        {
            conexionBd = new ConexionBd();
        }

        public List<Usuario> GetLista()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT SocioId, Dni, Apellido, Nombre, Direccion, Localidad, CodPostal, Telefono, FechaNac, Sancionado, RowVersion FROM Usuarios";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario Usuario = ConstruirUsuario(reader);
                            lista.Add(Usuario);
                        }

                    }
                }

                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private Usuario ConstruirUsuario(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.SocioId = reader.GetInt32(0);
            usuario.Dni = reader.GetInt32(1);
            usuario.Apellido = reader.GetString(2);
            usuario.Nombre = reader.GetString(3);
            usuario.Direccion = reader.GetString(4);
            usuario.Localidad = reader.GetString(5);
            usuario.CodPostal = reader.GetInt32(6);
            usuario.Telefono = reader.GetString(7);
            usuario.FechaNac = reader.GetDateTime(8);
            usuario.Sancionado = reader.GetBoolean(9);
            usuario.RowVersion = (byte[])reader[10];
            return usuario;
        }
    }
}