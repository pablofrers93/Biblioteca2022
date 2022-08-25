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
    public class AutoresRepositorio
    {
        private readonly ConexionBd conexionBd;

        public AutoresRepositorio()
        {
            conexionBd = new ConexionBd();
        }

        public List<Autor> GetLista()
        {
            List<Autor> lista = new List<Autor>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT AutorId, Apellido, Nombre, Nacionalidad,  RowVersion FROM Autores ORDER BY Apellido";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var Autor = ConstruirAutor(reader);
                            lista.Add(Autor);
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Error al leer de la tabla de Autores");
            }
        }

        private Autor ConstruirAutor(SqlDataReader reader)
        {
            Autor autor = new Autor();
            autor.AutorId = reader.GetInt32(0);
            autor.Apellido = reader.GetString(1);
            autor.Nombre = reader[2] != DBNull.Value ? reader.GetString(2) : String.Empty;
            autor.Nacionalidad = reader[3] != DBNull.Value ? reader.GetString(3) : String.Empty;
            autor.RowVersion = (byte[])reader[4];
            return autor;
        }

        public int Agregar(Autor autor)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "INSERT INTO Autores (Apellido, Nombre) VALUES (@nom,@ape)";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", autor.Nombre);
                    comando.Parameters.AddWithValue("@ape", autor.Apellido);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        autor.AutorId = (int)(decimal)comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM Autor WHERE AutorId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", autor.AutorId);
                        autor.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Autor repetido");
                }

                throw new Exception(e.Message);
            }
        }

        public int Borrar(Autor autor)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM Autores WHERE AutorId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", autor.AutorId);
                    comando.Parameters.AddWithValue("@r", autor.RowVersion);
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

        public int Editar(Autor autor)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "UPDATE Autores SET Nombre=@nom WHERE AutorId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", autor.Nombre);
                    comando.Parameters.AddWithValue("@id", autor.AutorId);
                    comando.Parameters.AddWithValue("@r", autor.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM Autores WHERE AutorId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", autor.AutorId);
                        autor.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Autor repetido");
                }
                throw new Exception(e.Message);
            }
        }
    }
}