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
    public class LibrosRepositorio
    {
        private readonly ConexionBd conexionBd;

        public LibrosRepositorio()
        {
            conexionBd = new ConexionBd();
        }

        public List<Libro> GetLista()
        {
            List<Libro> lista = new List<Libro>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT LibroId, Titulo, AutorId, Ejemplares, GeneroId, IdiomaId, EditorialId, Precio, RowVersion FROM Libros";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Libro Libro = ConstruirLibro(reader);
                            lista.Add(Libro);
                        }
                    }
                    SetAutor(cn, lista);
                    SetGenero(cn, lista);
                    SetIdioma(cn, lista);
                    SetEditorial(cn, lista);
                }

                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        private void SetEditorial(SqlConnection cn, List<Libro> lista)
        {
            foreach (var libro in lista)
            {
                libro.Editorial = SetEditorialLibro(cn, libro.EditorialId);
            }
        }

        private Editorial SetEditorialLibro(SqlConnection cn, int editorialId)
        {
            Editorial editorial = null;
            var cadenaComando = "SELECT EditorialId, NombreEditorial, RowVersion FROM Editoriales WHERE EditorialId=@id";
            var comando = new SqlCommand(cadenaComando, cn);
            comando.Parameters.AddWithValue("@id", editorialId);
            using (var reader = comando.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    editorial = ConstruirEditorial(reader);
                }
            }
            return editorial;
        }

        private Editorial ConstruirEditorial(SqlDataReader reader)
        {
            return new Editorial()
            {
                EditorialId = reader.GetInt32(0),
                NombreEditorial = reader.GetString(1),
                RowVersion = (byte[])reader[2]
            };
        }

        private void SetIdioma(SqlConnection cn, List<Libro> lista)
        {
            foreach (var libro in lista)
            {
                libro.Idioma = SetIdiomaLibro(cn, libro.IdiomaId);
            }
        }

        private Idioma SetIdiomaLibro(SqlConnection cn, int idiomaId)
        {
            Idioma idioma = null;
            var cadenaComando = "SELECT IdiomaId, Descripcion, RowVersion FROM Idiomas WHERE IdiomaId=@id";
            var comando = new SqlCommand(cadenaComando, cn);
            comando.Parameters.AddWithValue("@id", idiomaId);
            using (var reader = comando.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    idioma = ConstruirIdioma(reader);
                }
            }
            return idioma;
        }

        private Idioma ConstruirIdioma(SqlDataReader reader)
        {
            return new Idioma()
            {
                IdiomaId = reader.GetInt32(0),
                Descripcion = reader.GetString(1),
                RowVersion = (byte[])reader[2]
            };
        }

        private void SetGenero(SqlConnection cn, List<Libro> lista)
        {
            foreach (var libro in lista)
            {
                libro.Genero = SetGeneroLibro(cn, libro.GeneroId);
            }
        }

        private GeneroLiterario SetGeneroLibro(SqlConnection cn, int generoId)
        {
            GeneroLiterario genero = null;
            var cadenaComando = "SELECT GeneroLiterarioId, Descripcion, RowVersion FROM GenerosLiterarios WHERE GeneroLiterarioId=@id";
            var comando = new SqlCommand(cadenaComando, cn);
            comando.Parameters.AddWithValue("@id", generoId);
            using (var reader = comando.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    genero = ConstruirGenero(reader);
                }
            }
            return genero;
        }

        private GeneroLiterario ConstruirGenero(SqlDataReader reader)
        {
            return new GeneroLiterario()
            {
                GeneroLiterarioId = reader.GetInt32(0),
                Descripcion= reader.GetString(1),
                RowVersion = (byte[])reader[2]
            };
        }

        private void SetAutor(SqlConnection cn, List<Libro> lista)
        {
            foreach (var libro in lista)
            {
                libro.Autor = SetDatosAutor(cn, libro.AutorId);
            }
        }

        private Autor SetDatosAutor(SqlConnection cn, int autorId)
        {
            Autor autor = null;
            var cadenaComando = "SELECT AutorId, Apellido, Nombre, Nacionalidad,  RowVersion FROM Autores WHERE AutorId=@id";
            var comando = new SqlCommand(cadenaComando, cn);
            comando.Parameters.AddWithValue("@id", autorId);
            using (var reader = comando.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    autor = ConstruirAutor(reader);
                }
            }
            return autor;
        }

        private Autor ConstruirAutor(SqlDataReader reader)
        {
            return new Autor()
            {
                AutorId = reader.GetInt32(0),
                Apellido = reader.GetString(1),
                Nombre = reader[2] != DBNull.Value ? reader.GetString(2):String.Empty,
                Nacionalidad = reader[3] != DBNull.Value ? reader.GetString(3) : String.Empty,
                RowVersion = (byte[])reader[4]
            };
        }

        private Libro ConstruirLibro(SqlDataReader reader)
        {
            return new Libro()
            {
                LibroId = reader.GetInt32(0),
                Titulo = reader.GetString(1),
                AutorId = reader.GetInt32(2),
                Ejemplares = reader.GetInt32(3),
                GeneroId = reader.GetInt32(4),
                IdiomaId = reader.GetInt32(5),
                EditorialId = reader.GetInt32(6),
                Precio = reader.GetDecimal(7),
                RowVersion = (byte[])reader[8]

            };
        }

        public int Agregar(Libro Libro)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "INSERT INTO Libros (Titulo, Precio) VALUES (@titulo, @precio)";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@titulo", Libro.Titulo);
                    comando.Parameters.AddWithValue("@pre", Libro.Precio);

                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        Libro.LibroId = (int)(decimal)comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM Libros WHERE LibroId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", Libro.LibroId);
                        Libro.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Libro repetido");
                }

                throw new Exception(e.Message);
            }
        }

        public int Borrar(Libro Libro)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM Libros WHERE LibroId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", Libro.LibroId);
                    comando.Parameters.AddWithValue("@r", Libro.RowVersion);
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

        public int Editar(Libro Libro)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "UPDATE Libros SET Titulo=@titulo, Precio=@precio WHERE LibroId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@titulo", Libro.Titulo);
                    comando.Parameters.AddWithValue("@precio", Libro.Precio);
                    comando.Parameters.AddWithValue("@id", Libro.LibroId);
                    comando.Parameters.AddWithValue("@r", Libro.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM Libros WHERE LibroId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", Libro.LibroId);
                        Libro.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Libro repetido");
                }
                throw new Exception(e.Message);
            }
        }

    }
}

