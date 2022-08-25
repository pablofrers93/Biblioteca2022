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
    public class GenerosRepositorio
    {
        private readonly ConexionBd conexionBd;

        public GenerosRepositorio()
        {
            conexionBd = new ConexionBd();
        }
        public List<GeneroLiterario> GetLista()
        {
            List<GeneroLiterario> lista = new List<GeneroLiterario>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT GeneroLiterarioId, Descripcion,  RowVersion FROM GeneroLiterarioes ORDER BY Descripcion";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var GeneroLiterario = ConstruirGeneroLiterario(reader);
                            lista.Add(GeneroLiterario);
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Error al leer de la tabla de Generos Literarios");
            }
        }

        private GeneroLiterario ConstruirGeneroLiterario(SqlDataReader reader)
        {
            GeneroLiterario genero = new GeneroLiterario();
            genero.GeneroLiterarioId = reader.GetInt32(0);
            genero.Descripcion = reader.GetString(1);
            genero.RowVersion = (byte[])reader[2];
            return genero;
        }

        public int Agregar(GeneroLiterario genero)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "INSERT INTO GenerosLiterarios (Descripcion) VALUES (@descripcion)";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@descripcion", genero.Descripcion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        genero.GeneroLiterarioId = (int)(decimal)comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM GenerosLiterarios WHERE GeneroLiterarioId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", genero.GeneroLiterarioId);
                        genero.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Genero Literario repetido");
                }

                throw new Exception(e.Message);
            }
        }

        public int Borrar(GeneroLiterario genero)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM GenerosLiterarios WHERE GeneroLiterarioId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", genero.GeneroLiterarioId);
                    comando.Parameters.AddWithValue("@r", genero.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro relacionado... baja denegada");
                }
                throw new Exception(e.Message);
            }
        }

        public int Editar(GeneroLiterario genero)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "UPDATE GenerosLiterarios SET Descripcion=@descripcion WHERE GeneroLiterarioId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", genero.Descripcion);
                    comando.Parameters.AddWithValue("@id", genero.GeneroLiterarioId);
                    comando.Parameters.AddWithValue("@r", genero.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM GenerosLiterarios WHERE GeneroLiterarioId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", genero.GeneroLiterarioId);
                        genero.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Genero Literario repetido");
                }
                throw new Exception(e.Message);
            }
        }
    }
}