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
    public class IdiomasRepositorio
    {
        private readonly ConexionBd conexionBd;

        public IdiomasRepositorio()
        {
            conexionBd = new ConexionBd();
        }

        public List<Idioma> GetLista()
        {
            List<Idioma> lista = new List<Idioma>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT IdiomaId, Descripcion, RowVersion FROM Idiomas ORDER BY Descripcion";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var Idioma = ConstruirIdioma(reader);
                            lista.Add(Idioma);
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Error al leer de la tabla de Idiomas");
            }
        }

        private Idioma ConstruirIdioma(SqlDataReader reader)
        {
            Idioma idioma = new Idioma();
            idioma.IdiomaId = reader.GetInt32(0);
            idioma.Descripcion = reader.GetString(1); 
            idioma.RowVersion = (byte[])reader[2];
            return idioma;
        }

        public int Agregar(Idioma idioma)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "INSERT INTO Idiomas (Descripcion) VALUES (@descripcion)";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@descripcion", idioma.Descripcion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        idioma.IdiomaId = (int)(decimal)comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM Idioma WHERE IdiomaId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", idioma.IdiomaId);
                        idioma.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Idioma repetido");
                }

                throw new Exception(e.Message);
            }
        }

        public int Borrar(Idioma idioma)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM Idiomas WHERE IdiomaId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", idioma.IdiomaId);
                    comando.Parameters.AddWithValue("@r", idioma.RowVersion);
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

        public int Editar(Idioma idioma)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "UPDATE Idiomas SET Descripcion=@descripcion WHERE IdiomaId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@descripcion", idioma.Descripcion);
                    comando.Parameters.AddWithValue("@id", idioma.IdiomaId);
                    comando.Parameters.AddWithValue("@r", idioma.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM Idiomas WHERE IdiomaId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", idioma.IdiomaId);
                        idioma.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Idioma repetido");
                }
                throw new Exception(e.Message);
            }
        }
    }
}
