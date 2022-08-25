using Biblioteca2022.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca2022.WINDOWS
{
    public partial class frmLibrosAE : Form
    {
        public frmLibrosAE()
        {
            InitializeComponent();
        }

        private Libro libro;

        public Libro GetLibro()
        {
            return libro;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (libro != null)
            {
                TituloLibroTextBox.Text = libro.Titulo;
                AutorLibroTextBox.Text = Convert.ToString(libro.Autor);
                EjemplaresTextBox.Text = Convert.ToString(libro.Ejemplares);
                GeneroTextBox.Text = Convert.ToString(libro.Genero);
                IdiomaTextBox.Text = Convert.ToString(libro.Idioma);
                EditorialTextBox.Text = Convert.ToString(libro.Editorial);
                PrecioTextBox.Text = Convert.ToString(libro.Precio);
            }
        }
        private void frmLibrosAE_Load(object sender, EventArgs e)
        {

        }

        public void SetLibro(Libro libro)
        {
            this.libro = libro;
        }

        private void GuadarButton_Click(object sender, EventArgs e)
        {
            if (libro == null)
            {
                libro = new Libro();
            }

            libro.Titulo = TituloLibroTextBox.Text;
            libro.Autor.Nombre= AutorLibroTextBox.Text;
            libro.Ejemplares = Convert.ToInt32(EjemplaresTextBox.Text);
            libro.Genero.Descripcion = GeneroTextBox.Text;
            libro.Idioma.Descripcion = IdiomaTextBox.Text;
            libro.Editorial.NombreEditorial = EditorialTextBox.Text;
            libro.Precio = Convert.ToInt32(PrecioTextBox.Text);
            DialogResult = DialogResult.OK;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
