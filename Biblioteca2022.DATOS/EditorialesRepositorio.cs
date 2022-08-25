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
    public class EditorialesRepositorio
    {
        private readonly ConexionBd conexionBd;

        public EditorialesRepositorio()
        {
            conexionBd = new ConexionBd();
        }

        public List<Editorial> GetLista()
        {
            List<Editorial> lista = new List<Editorial>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT EditorialId, NombreEditorial, RowVersion FROM Editoriales ORDER BY NombreEditorial";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var Editorial = ConstruirEditorial(reader);
                            lista.Add(Editorial);
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Error al leer de la tabla de Editoriales");
            }
        }

        private Editorial ConstruirEditorial(SqlDataReader reader)
        {
            Editorial editorial = new Editorial();
            editorial.EditorialId = reader.GetInt32(0);
            editorial.NombreEditorial = reader.GetString(1);
            editorial.RowVersion = (byte[])reader[2];
            return editorial;
        }

        public int Agregar(Editorial editorial)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "INSERT INTO Editoriales (NombreEditorial) VALUES (@nom)";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", editorial.NombreEditorial);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        editorial.EditorialId = (int)(decimal)comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM Editoriales WHERE EditorialId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", editorial.EditorialId);
                        editorial.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Editorial repetida");
                }

                throw new Exception(e.Message);
            }
        }

        public int Borrar(Editorial editorial)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM Editoriales WHERE EditorialId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", editorial.EditorialId);
                    comando.Parameters.AddWithValue("@r", editorial.RowVersion);
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

        public int Editar(Editorial editorial)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "UPDATE Editoriales SET NombreEditorial=@nom WHERE EditorialId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", editorial.NombreEditorial);
                    comando.Parameters.AddWithValue("@id", editorial.EditorialId);
                    comando.Parameters.AddWithValue("@r", editorial.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM Editoriales WHERE EditorialId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", editorial.EditorialId);
                        editorial.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Editorial repetida");
                }
                throw new Exception(e.Message);
            }
        }
    }
}
